using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Helper;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Helper;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Commands.Profile
{
    public class UploadPhotoValidationCommand : IBaseCommand<bool>
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
            var obj = await _repo.Get<ProfileVM>(request.Id);
            if (obj == null || string.IsNullOrEmpty(obj.MainPhoto)) throw new NotificationException("Foto para validação não encontrada. Favor, inserir primeiro sua foto de rosto.");

            var NewPhotoId = Guid.NewGuid().ToString();
            //obj.PhotoFaceValidation = NewPhotoId + ".jpg";

            using (var ms = new MemoryStream(request.Stream))
            {
                var validated = await FaceHelper.IsPhotoValid(obj.MainPhoto, ms);

                if (validated)
                {
                    await storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoValidation, ms, NewPhotoId);
                    //await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoValidation, obj.PhotoFaceValidation);

                    await _repo.Update(obj);
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