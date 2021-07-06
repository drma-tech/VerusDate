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
    public class UploadPhotoValidationCommand : CosmosBase, IRequest<bool>
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

    public class UploadPhotoVaildationHandler : IRequestHandler<UploadPhotoValidationCommand, bool>
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

        public async Task<bool> Handle(UploadPhotoValidationCommand request, CancellationToken cancellationToken)
        {
            var profile = await _repo.Get<ProfileModel>(request.Id, request.Key, cancellationToken);
            if (profile == null || string.IsNullOrEmpty(profile.Photo.Main)) throw new NotificationException("Foto para validação não encontrada. Favor, inserir primeiro sua foto de rosto.");
            if (profile.Photo.DtMainUpload < DateTime.UtcNow.AddHours(-24)) throw new NotificationException("Foto postada a mais de 24 horas. Favor, reenviar sua foto principal.");

            using var streamValidation = new MemoryStream(request.Stream);

            var identical = await faceHelper.IsPhotoIdentical(profile, streamValidation, cancellationToken);

            if (identical)
            {
                using var streamStorage = new MemoryStream(request.Stream);

                var photoName = Guid.NewGuid().ToString() + ".jpg";

                await storageHelper.UploadPhoto(ImageHelper.PhotoType.PhotoValidation, streamStorage, photoName, cancellationToken);
                //await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoValidation, obj.PhotoFaceValidation);

                profile.Photo.Validation = photoName;

                return await _repo.Update(profile, cancellationToken);
                //await _appValidation.ValidatePhotoFace(request.Id, true, cancellationToken);
            }
            else
            {
                throw new ValidationException("Não foi possível validar sua foto. Favor, tentar novamente.");
            }
        }
    }
}