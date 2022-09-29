using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Mediator.Commands.Profile
{
    public class UploadPhotoFaceCommand : CosmosBase, IRequest<ProfileModel>
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

    public class UploadPhotoFaceHandler : IRequestHandler<UploadPhotoFaceCommand, ProfileModel>
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

        public async Task<ProfileModel> Handle(UploadPhotoFaceCommand request, CancellationToken cancellationToken)
        {
            var profile = await _repo.Get<ProfileModel>(request.Id, request.Key, cancellationToken);
            if (profile == null) throw new NotificationException("Perfil não encontrado");
            var IdOldPhoto = profile.Photo?.Main;

            using var stream1 = new MemoryStream(request.MainPhoto);

            if (profile.Photo == null) profile.Photo = new ProfilePhotoModel();

            var photoName = Guid.NewGuid().ToString() + ".jpg";
            profile.Photo.UpdateMainPhoto(photoName); //reset current photo data

            await faceHelper.DetectFace(profile, stream1, true, cancellationToken); //validates the photo sent and saves data related to it

            if (!string.IsNullOrEmpty(profile.Photo.Main)) //foto já existente
            {
                //if you keep the photo with the same id, the browser cache will not update the photo
                await storageHelper.DeletePhoto(ImageHelper.PhotoType.PhotoFace, IdOldPhoto, cancellationToken);
            }

            using var stream2 = new MemoryStream(request.MainPhoto);

            await storageHelper.UploadPhoto(ImageHelper.PhotoType.PhotoFace, stream2, photoName, cancellationToken);

            profile.UpdatePhoto(profile.Photo);

            return await _repo.Update(profile, cancellationToken);
        }
    }
}