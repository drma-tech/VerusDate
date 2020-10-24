using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Helper;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Interface.App;

namespace VerusDate.Server.Mediator.Commands
{
    #region PHOTO-FACE

    public class UploadPhotoFaceCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public byte[] Stream { get; set; }
    }

    public class UploadPhotoFaceHandler : IRequestHandler<UploadPhotoFaceCommand, bool>
    {
        private readonly IProfilePhotosApp _app;
        private readonly IProfileValidationApp _profileValidationApp;
        private readonly IGamificationApp _gamificationApp;
        private readonly StorageHelper _storageHelper;

        public UploadPhotoFaceHandler(IProfilePhotosApp app, IProfileValidationApp profileValidationApp, IGamificationApp gamificationApp, StorageHelper storageHelper)
        {
            _app = app;
            _profileValidationApp = profileValidationApp;
            _gamificationApp = gamificationApp;
            _storageHelper = storageHelper;
        }

        public async Task<bool> Handle(UploadPhotoFaceCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var pp = await _app.Get(request.Id, cancellationToken);
            var pv = await _profileValidationApp.Get(request.Id, cancellationToken);

            var NewPhotoId = Guid.NewGuid().ToString();

            using (var ms = new MemoryStream(request.Stream))
            {
                await _storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoFace, ms, NewPhotoId);
            }
            if (pp != null) await _storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoFace, pp.PhotoFace);

            if (!pv.PhotoFace.HasValue) //só adiciona XP se for a primeira validação de foto
            {
                await _gamificationApp.AddXP(request.Id, EventAddXP.ValidatePhotoFace, cancellationToken);
            }

            await _profileValidationApp.ValidatePhotoFace(request.Id, false, cancellationToken); //undo the photo validation

            return await _app.PhotoFace(request.Id, NewPhotoId + ".jpg", cancellationToken);
        }
    }

    #endregion PHOTO-FACE

    #region PHOTO-GALLERY

    public class UploadPhotoGalleryCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public byte[] Stream1 { get; set; }
        public byte[] Stream2 { get; set; }
        public byte[] Stream3 { get; set; }
        public byte[] Stream4 { get; set; }
    }

    public class UploadPhotoGalleryHandler : IRequestHandler<UploadPhotoGalleryCommand, bool>
    {
        private readonly IProfilePhotosApp _app;
        private readonly StorageHelper storageHelper;

        public UploadPhotoGalleryHandler(IProfilePhotosApp app, StorageHelper storageHelper)
        {
            _app = app;
            this.storageHelper = storageHelper;
        }

        public async Task<bool> Handle(UploadPhotoGalleryCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var obj = await _app.Get(request.Id, cancellationToken);
            if (obj == null) throw new NotificationException("Perfil não encontrado");

            var NewPhotoId1 = Guid.NewGuid().ToString();
            var NewPhotoId2 = Guid.NewGuid().ToString();
            var NewPhotoId3 = Guid.NewGuid().ToString();
            var NewPhotoId4 = Guid.NewGuid().ToString();

            using (var Stream1 = new MemoryStream(request.Stream1))
            {
                await storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoGallery, Stream1, NewPhotoId1);
                await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoGallery, obj.PhotoGallery1);
            }

            using (var Stream2 = new MemoryStream(request.Stream2))
            {
                await storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoGallery, Stream2, NewPhotoId2);
                await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoGallery, obj.PhotoGallery2);
            }

            using (var Stream3 = new MemoryStream(request.Stream3))
            {
                await storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoGallery, Stream3, NewPhotoId3);
                await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoGallery, obj.PhotoGallery3);
            }

            using (var Stream4 = new MemoryStream(request.Stream4))
            {
                await storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoGallery, Stream4, NewPhotoId4);
                await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoGallery, obj.PhotoGallery4);
            }

            obj.PhotoGallery1 = NewPhotoId1 + ".jpg";
            obj.PhotoGallery2 = NewPhotoId2 + ".jpg";
            obj.PhotoGallery3 = NewPhotoId3 + ".jpg";
            obj.PhotoGallery4 = NewPhotoId4 + ".jpg";
            return true;
            //return await _app.Update(obj, cancellationToken);
        }
    }

    #endregion PHOTO-GALLERY

    #region PHOTO-VALIDATION

    public class UploadPhotoValidationCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public byte[] Stream { get; set; }
    }

    public class UploadPhotoVaildationHandler : IRequestHandler<UploadPhotoValidationCommand, bool>
    {
        private readonly IProfilePhotosApp _appPhoto;
        private readonly IProfileValidationApp _appValidation;
        private readonly StorageHelper storageHelper;

        public UploadPhotoVaildationHandler(IProfilePhotosApp appPhoto, IProfileValidationApp appValidation, StorageHelper storageHelper)
        {
            _appPhoto = appPhoto;
            _appValidation = appValidation;
            this.storageHelper = storageHelper;
        }

        public async Task<bool> Handle(UploadPhotoValidationCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var obj = await _appPhoto.Get(request.Id, cancellationToken);
            if (obj == null || string.IsNullOrEmpty(obj.PhotoFace)) throw new NotificationException("Foto para validação não encontrada. Favor, inserir primeiro sua foto de rosto.");

            var NewPhotoId = Guid.NewGuid().ToString();
            obj.PhotoFaceValidation = NewPhotoId + ".jpg";

            using (var ms = new MemoryStream(request.Stream))
            {
                var validated = await FaceHelper.IsPhotoValid(obj.PhotoFace, ms);

                if (validated)
                {
                    await storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoValidation, ms, NewPhotoId);
                    await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoValidation, obj.PhotoFaceValidation);

                    //await _appPhoto.Update(obj, cancellationToken);
                    await _appValidation.ValidatePhotoFace(request.Id, true, cancellationToken);

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    #endregion PHOTO-VALIDATION
}