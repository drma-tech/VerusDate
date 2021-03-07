using MediatR;
using Microsoft.Azure.Cosmos;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Server.Core.Helper;
using VerusDate.Shared.Core;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Mediator.Commands.Profile
{
    public class UploadPhotoFaceCommand : CosmosBase, IRequest<bool>
    {
        public UploadPhotoFaceCommand() : base(CosmosType.Profile)
        {
        }

        public byte[] MainPhoto { get; set; }

        public override void SetIds(string IdLoggedUser)
        {
            this.SetId(IdLoggedUser);
            this.SetPartitionKey(IdLoggedUser);
        }
    }

    public class UploadPhotoFaceHandler : IRequestHandler<UploadPhotoFaceCommand, bool>
    {
        private readonly IRepository _repo;
        private readonly StorageHelper storageHelper;
        private readonly FaceHelper faceHelper;

        public UploadPhotoFaceHandler(IRepository repo, StorageHelper storageHelper, FaceHelper faceHelper)
        {
            _repo = repo;
            this.storageHelper = storageHelper;
            this.faceHelper = faceHelper;
        }

        public async Task<bool> Handle(UploadPhotoFaceCommand request, CancellationToken cancellationToken)
        {
            var profile = await _repo.Get<ProfileModel>(request.Id, new PartitionKey(request.Key), cancellationToken);
            if (profile == null) throw new NotificationException("Perfil não encontrado");

            using var stream1 = new MemoryStream(request.MainPhoto);

            if (profile.Photo == null) profile.Photo = new ProfilePhotoModel();

            var photoName = Guid.NewGuid().ToString() + ".jpg";
            profile.Photo.UpdateMainPhoto(photoName); //reseta dados da foto atual

            await faceHelper.DetectFace(profile, stream1, true, cancellationToken); //valida a foto enviada e salva dados relativos a ela

            if (!string.IsNullOrEmpty(profile.Photo.Main)) //foto já existente
            {
                //se manter a foto com o mesmo id, o cache do browser não vai atualizar a foto
                await storageHelper.DeletePhoto(ImageHelper.PhotoType.PhotoFace, profile.Photo.Main, cancellationToken);
            }

            using var stream2 = new MemoryStream(request.MainPhoto);

            await storageHelper.UploadPhoto(ImageHelper.PhotoType.PhotoFace, stream2, photoName, cancellationToken);

            profile.UpdatePhoto(profile.Photo);

            return await _repo.Update(profile, cancellationToken);
        }
    }
}