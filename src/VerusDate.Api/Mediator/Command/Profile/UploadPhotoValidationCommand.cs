using MediatR;
using Microsoft.Azure.CosmosRepository;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Server.Core.Helper;
using VerusDate.Shared.Helper;

namespace VerusDate.Server.Mediator.Commands.Profile
{
    public class UploadPhotoValidationCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public byte[] Stream { get; set; }
    }

    public class UploadPhotoVaildationHandler : IRequestHandler<UploadPhotoValidationCommand, bool>
    {
        private readonly IRepository<Shared.Model.Profile.Profile> _repo;
        private readonly StorageHelper storageHelper;

        public UploadPhotoVaildationHandler(IRepositoryFactory factory, StorageHelper storageHelper)
        {
            _repo = factory.RepositoryOf<Shared.Model.Profile.Profile>();
            this.storageHelper = storageHelper;
        }

        public async Task<bool> Handle(UploadPhotoValidationCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);
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

                    await _repo.UpdateAsync(obj, cancellationToken);
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