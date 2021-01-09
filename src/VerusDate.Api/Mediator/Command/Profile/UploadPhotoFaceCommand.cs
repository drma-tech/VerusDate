using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Mediator.Commands.Profile
{
    public class UploadPhotoFaceCommand : IRequest<ProfileModel>
    {
        public string Id { get; set; }
        public byte[] MainPhoto { get; set; }
    }

    public class UploadPhotoFaceHandler : IRequestHandler<UploadPhotoFaceCommand, ProfileModel>
    {
        private readonly IRepository _repo;
        private readonly StorageHelper storageHelper;

        public UploadPhotoFaceHandler(IRepository repo, StorageHelper storageHelper)
        {
            _repo = repo;
            this.storageHelper = storageHelper;
        }

        public async Task<ProfileModel> Handle(UploadPhotoFaceCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<ProfileModel>(request.Id, request.Id, cancellationToken);
            if (obj == null) throw new NotificationException("Perfil não encontrado");

            using (var stream = new MemoryStream(request.MainPhoto))
            {
                if (obj.Photo != null && !string.IsNullOrEmpty(obj.Photo.Main)) //foto já existente
                {
                    //se manter a foto com o mesmo id, o cache do browser não vai atualizar a foto
                    await storageHelper.DeletePhoto(ImageHelper.PhotoType.PhotoFace, obj.Photo.Main, cancellationToken);
                }
                else
                {
                    obj.Photo = new ProfilePhotoModel();
                }

                var photoName = Guid.NewGuid().ToString() + ".jpg";

                await storageHelper.UploadPhoto(ImageHelper.PhotoType.PhotoFace, stream, photoName, cancellationToken);

                obj.Photo.Main = photoName;

                obj.UpdatePhoto(obj.Photo);
            }

            return await _repo.Update(obj, request.Id, request.Id, cancellationToken);
        }
    }
}