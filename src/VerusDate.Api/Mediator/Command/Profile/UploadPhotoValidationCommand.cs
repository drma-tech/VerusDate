using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Server.Core.Helper;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Mediator.Commands.Profile
{
    public class UploadPhotoValidationCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public byte[] Stream { get; set; }
    }

    public class UploadPhotoVaildationHandler : IRequestHandler<UploadPhotoValidationCommand, bool>
    {
        private readonly IRepository _repo;
        private readonly StorageHelper storageHelper;

        public UploadPhotoVaildationHandler(IRepository repo, StorageHelper storageHelper)
        {
            _repo = repo;
            this.storageHelper = storageHelper;
        }

        public async Task<bool> Handle(UploadPhotoValidationCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<ProfileModel>(request.Id, request.Id, cancellationToken);
            if (obj == null || string.IsNullOrEmpty(obj.Photo.Main)) throw new NotificationException("Foto para validação não encontrada. Favor, inserir primeiro sua foto de rosto.");

            var NewPhotoId = Guid.NewGuid().ToString();
            //obj.PhotoFaceValidation = NewPhotoId + ".jpg";

            using (var ms = new MemoryStream(request.Stream))
            {
                var validated = await FaceHelper.IsPhotoValid(obj.Photo.Main, ms);

                if (validated)
                {
                    await storageHelper.UploadPhoto(ImageHelper.PhotoType.PhotoValidation, ms, NewPhotoId, cancellationToken);
                    //await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoValidation, obj.PhotoFaceValidation);

                    await _repo.Update(obj, request.Id, request.Id, cancellationToken);
                    //await _appValidation.ValidatePhotoFace(request.Id, true, cancellationToken);

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}