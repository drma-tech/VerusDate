using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Core.Helper
{
    public class FaceHelper
    {
        public IConfiguration Configuration { get; }

        public FaceHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IFaceClient Authenticate(string endpoint, string key)
        {
            return new FaceClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };
        }

        public async Task<bool> IsPhotoValid(ProfileModel profile, Stream StreamPhotoCamera, CancellationToken cancellationToken)
        {
            IFaceClient client = Authenticate(Configuration.GetValue<string>("CognitivePath"), Configuration.GetValue<string>("CognitiveKey"));

            var verify = await VerifyFaces(client, Configuration.GetValue<string>("BlobPath"), profile, StreamPhotoCamera, cancellationToken);

            profile.Photo.Confidence = verify.Confidence;

            return verify.IsIdentical;
        }

        public static async Task<VerifyResult> VerifyFaces(IFaceClient client, string url, ProfileModel profile, Stream StreamPhotoCamera, CancellationToken cancellationToken)
        {
            var photoFace = await DetectFaceFromUrl(client, profile, $"{url}/photo-face/{profile.Photo.Main}", cancellationToken);
            var photoCamera = await DetectFaceFromStream(client, StreamPhotoCamera, cancellationToken);
            
            return await client.Face.VerifyFaceToFaceAsync(photoFace.FaceId.Value, photoCamera.FaceId.Value, cancellationToken);
        }

        /// <summary>
        /// Detecta a foto armazenada no storage (foto principal)
        /// </summary>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<DetectedFace> DetectFaceFromUrl(IFaceClient client, ProfileModel profile, string url, CancellationToken cancellationToken)
        {
            var faces = await client.Face.DetectWithUrlAsync(url,
                          returnFaceAttributes: new List<FaceAttributeType?> { FaceAttributeType.Age, FaceAttributeType.Gender },
                          recognitionModel: RecognitionModel.Recognition03, cancellationToken: cancellationToken);

            if (faces.Count == 0)
            {
                throw new NotificationException("Não foi possível detectar um rosto nesta foto");
            }
            else if (faces.Count > 1)
            {
                throw new NotificationException("Foi detectado mais de um rosto na sua foto principal, favor colocar apenas você para a foto principal");
            }
            else
            {
                var face = faces.First();

                profile.Photo.Age = face.FaceAttributes.Age;
                profile.Photo.Gender = face.FaceAttributes.Gender switch
                {
                    Gender.Male => Shared.Enum.BiologicalSex.Male,
                    Gender.Female => Shared.Enum.BiologicalSex.Female,
                    _ => Shared.Enum.BiologicalSex.Other,
                };

                return face;
            }
        }

        /// <summary>
        /// Detecta a foto tirada pela camera, para validação
        /// </summary>
        /// <param name="client"></param>
        /// <param name="Stream"></param>
        /// <returns></returns>
        public static async Task<DetectedFace> DetectFaceFromStream(IFaceClient client, Stream Stream, CancellationToken cancellationToken)
        {
            var faces = await client.Face.DetectWithStreamAsync(Stream,
                          //returnFaceAttributes: new List<FaceAttributeType?> { FaceAttributeType.Age, FaceAttributeType.Gender },
                          recognitionModel: RecognitionModel.Recognition03, cancellationToken: cancellationToken);

            if (faces.Count == 0)
            {
                throw new NotificationException("Não foi possível detectar um rosto na câmera");
            }
            else if (faces.Count > 1)
            {
                throw new NotificationException("Foi detectado mais de um rosto na sua câmera, favor deixar exposto apenas você");
            }
            else
            {
                return faces.First();
            }
        }
    }
}