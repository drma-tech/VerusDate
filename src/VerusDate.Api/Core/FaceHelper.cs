using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Core
{
    public class FaceHelper
    {
        public IConfiguration Configuration { get; }

        public FaceHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task DetectFace(ProfileModel profile, Stream StreamPhotoCamera, bool captureAttributes, CancellationToken cancellationToken)
        {
            IFaceClient client = CreateClient(Configuration.GetValue<string>("CognitivePath"), Configuration.GetValue<string>("CognitiveKey"));

            await DetectFaceFromStream(client, StreamPhotoCamera, profile, captureAttributes, cancellationToken);
        }

        public async Task<bool> IsPhotoIdentical(ProfileModel profile, Stream StreamPhotoCamera, CancellationToken cancellationToken)
        {
            IFaceClient client = CreateClient(Configuration.GetValue<string>("CognitivePath"), Configuration.GetValue<string>("CognitiveKey"));

            var verify = await VerifyFaces(client, profile, StreamPhotoCamera, false, cancellationToken);

            profile.Photo.Confidence = verify.Confidence;

            return verify.IsIdentical;
        }

        private static IFaceClient CreateClient(string endpoint, string key)
        {
            return new FaceClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };
        }

        private static async Task<DetectedFace> DetectFaceFromStream(IFaceClient client, Stream stream, ProfileModel profile, bool captureAttributes, CancellationToken cancellationToken)
        {
            var faces = await client.Face.DetectWithStreamAsync(stream,
                          returnFaceAttributes: GetAttributeTypes(captureAttributes),
                          recognitionModel: RecognitionModel.Recognition03,
                          cancellationToken: cancellationToken);

            if (faces.Count == 0)
            {
                throw new NotificationException("Não foi possível detectar um rosto na foto");
            }
            else if (faces.Count == 1)
            {
                var face = faces.First();

                if (captureAttributes)
                {
                    profile.Photo.Age = face.FaceAttributes.Age;
                    profile.Photo.Gender = face.FaceAttributes.Gender switch
                    {
                        Gender.Male => Shared.Enum.BiologicalSex.Male,
                        Gender.Female => Shared.Enum.BiologicalSex.Female,
                        _ => Shared.Enum.BiologicalSex.Other,
                    };
                    profile.Photo.FaceId = face.FaceId;
                    profile.Photo.DtMainUpload = DateTime.UtcNow;
                }

                return face;
            }
            else
            {
                throw new NotificationException("Foi detectado mais de um rosto na foto");
            }
        }

        private static List<FaceAttributeType> GetAttributeTypes(bool captureAttributes)
        {
            if (captureAttributes)
                return new List<FaceAttributeType> {
                    FaceAttributeType.Age,
                    FaceAttributeType.Gender
                };
            else
                return new List<FaceAttributeType>();
        }

        private static async Task<VerifyResult> VerifyFaces(IFaceClient client, ProfileModel profile, Stream StreamPhotoCamera, bool captureAttributes, CancellationToken cancellationToken)
        {
            var photoCamera = await DetectFaceFromStream(client, StreamPhotoCamera, profile, captureAttributes, cancellationToken);

            return await client.Face.VerifyFaceToFaceAsync(profile.Photo.FaceId.Value, photoCamera.FaceId.Value, cancellationToken);
        }
    }
}