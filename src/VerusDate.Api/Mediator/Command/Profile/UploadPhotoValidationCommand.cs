using Bogus;
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
    public class UploadPhotoValidationCommand : CosmosBase, IRequest<ProfileModel>
    {
        public UploadPhotoValidationCommand() : base(CosmosType.Profile)
        {
        }

        public byte[] Stream { get; set; }

        public override void SetIds(string IdLoggedUser)
        {
            this.SetId(IdLoggedUser);
            this.SetPartitionKey(IdLoggedUser);
        }
    }

    public class UploadPhotoVaildationHandler : IRequestHandler<UploadPhotoValidationCommand, ProfileModel>
    {
        private readonly IRepository _repo;
        private readonly StorageHelper storageHelper;
        private readonly FaceHelper faceHelper;

        public UploadPhotoVaildationHandler(IRepository repo, StorageHelper storageHelper, FaceHelper faceHelper)
        {
            _repo = repo;
            this.storageHelper = storageHelper;
            this.faceHelper = faceHelper;
        }

        public async Task<ProfileModel> Handle(UploadPhotoValidationCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<ProfileModel>(request.Id, new PartitionKey(request.Key), cancellationToken);
            if (obj == null || string.IsNullOrEmpty(obj.Photo.Main)) throw new NotificationException("Foto para validação não encontrada. Favor, inserir primeiro sua foto de rosto.");

            using (var streamValidation = new MemoryStream(request.Stream))
            {
                var validated = await faceHelper.IsPhotoValid(obj, streamValidation, cancellationToken);

                if (validated)
                {
                    using (var streamStorage = new MemoryStream(request.Stream))
                    {
                        var photoName = Guid.NewGuid().ToString() + ".jpg";

                        await storageHelper.UploadPhoto(ImageHelper.PhotoType.PhotoValidation, streamStorage, photoName, cancellationToken);
                        //await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoValidation, obj.PhotoFaceValidation);

                        obj.Photo.Validation = photoName;

                    return    await _repo.Update(obj, cancellationToken);
                        //await _appValidation.ValidatePhotoFace(request.Id, true, cancellationToken);
                    }
                }
                else
                {
                    throw new ValidationException("Não foi possível validar sua foto. Favor, tentar novamente.");
                }
            }
        }
    }
}