using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VerusDate.Api;
using VerusDate.Shared.Helper;

namespace VerusDate.Server.Core.Helper
{
    public static class FaceHelper
    {
        public static IFaceClient Authenticate(string endpoint, string key)
        {
            return new FaceClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };
        }

        public static async Task<bool> IsPhotoValid(string idPhotoFace, Stream StreamPhotoCamera)
        {
            //IFaceClient client = Authenticate(Startup.Configuration.GetValue<string>("CognitivePath"), "efdaf276808c4adb83778efeec621ba0");

            //var similar = await client.FindSimilar(Startup.Configuration.GetValue<string>("BlobPath"), idPhotoFace, StreamPhotoCamera);

            //return similar.Confidence > 0.6;

            return true;
        }

        public static async Task<SimilarFace> FindSimilar(this IFaceClient client, string url, string idPhotoFace, Stream StreamPhotoCamera)
        {
            var photoFace = await client.DetectFaceFromUrl($"{url}/photo-face/{idPhotoFace}");

            var targetFaceIds = new List<Guid?>
            {
                photoFace.FaceId.Value
            };

            var photoCamera = await client.DetectFaceFromStream(StreamPhotoCamera);

            var result = await client.Face.FindSimilarAsync(photoCamera.FaceId.Value, null, null, targetFaceIds);

            return result.First();
        }

        public static async Task<DetectedFace> DetectFaceFromUrl(this IFaceClient client, string url)
        {
            var faces = await client.Face.DetectWithUrlAsync(url,
                          returnFaceAttributes: new List<FaceAttributeType?> { FaceAttributeType.Age, FaceAttributeType.Gender },
                          recognitionModel: RecognitionModel.Recognition01);

            if (faces.Count == 0)
            {
                throw new NotificationException("Não foi possível detectar um rosto nesta foto");
            }
            else if (faces.Count > 1)
            {
                throw new NotificationException("Foi detetado mais de um rosto na sua foto, favor colocar apenas você para a foto principal");
            }
            else
            {
                return faces.First();
            }
        }

        public static async Task<DetectedFace> DetectFaceFromStream(this IFaceClient client, Stream Stream)
        {
            var faces = await client.Face.DetectWithStreamAsync(Stream,
                          returnFaceAttributes: new List<FaceAttributeType?> { FaceAttributeType.Age, FaceAttributeType.Gender },
                          recognitionModel: RecognitionModel.Recognition01);

            if (faces.Count == 0)
            {
                throw new NotificationException("Não foi possível detectar um rosto na câmera");
            }
            else if (faces.Count > 1)
            {
                throw new NotificationException("Foi detetado mais de um rosto na sua câmera, favor deixar exposto apenas você");
            }
            else
            {
                return faces.First();
            }
        }
    }
}