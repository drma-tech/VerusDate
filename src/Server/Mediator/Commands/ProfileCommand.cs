using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Helper;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Commands
{
    #region ADD

    public class ProfileAddCommand : ProfileUserVM, IRequest<bool>
    {
    }

    public class ProfileAddHandler : IRequestHandler<ProfileAddCommand, bool>
    {
        private readonly IProfileApp _app;
        private readonly IGamificationApp _gamificationApp;

        public ProfileAddHandler(IProfileApp app, IGamificationApp gamificationApp)
        {
            _app = app;
            _gamificationApp = gamificationApp;
        }

        public async Task<bool> Handle(ProfileAddCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            //var pv = await _profileValidationApp.Get(request.Id, cancellationToken);

            //if (!pv.ProfileData.HasValue)
            //{
            //    await _gamificationApp.AddXP(request.Id, EventAddXP.ValidateProfileData, cancellationToken);
            //}

            //await _profileValidationApp.ValidateProfileData(request.Id, true, cancellationToken);

            return await _app.Add(request);
        }
    }

    public class ProfileLookingAddCommand : ProfileLookingVM, IRequest<bool>
    {
    }

    public class ProfileLookingAddHandler : IRequestHandler<ProfileLookingAddCommand, bool>
    {
        private readonly IProfileLookingApp _app;
        private readonly IGamificationApp _gamificationApp;

        public ProfileLookingAddHandler(IProfileLookingApp app, IGamificationApp gamificationApp)
        {
            _app = app;
            _gamificationApp = gamificationApp;
        }

        public async Task<bool> Handle(ProfileLookingAddCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            //var obj = await _profileValidationApp.Get(request.Id, cancellationToken);

            //if (!obj.ProfileCriteria.HasValue)
            //{
            //    await _gamificationApp.AddXP(request.Id, EventAddXP.ValidateProfileCriteria, cancellationToken);
            //}

            //await _profileValidationApp.ValidateProfileCriteria(request.Id, true, cancellationToken);

            return await _app.Add(request, cancellationToken);
        }
    }

    #endregion ADD

    #region UPDATE

    public class ProfileUpdateCommand : ProfileUserVM, IRequest<bool>
    {
    }

    public class ProfileUpdateHandler : IRequestHandler<ProfileUpdateCommand, bool>
    {
        private readonly IProfileApp _app;
        private readonly IGamificationApp _gamificationApp;

        public ProfileUpdateHandler(IProfileApp app, IGamificationApp gamificationApp)
        {
            _app = app;
            _gamificationApp = gamificationApp;
        }

        public async Task<bool> Handle(ProfileUpdateCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            await _gamificationApp.RemoveXP(request.Id, EventRemoveXP.UpdateProfile, cancellationToken);

            return await _app.Update(request);
        }
    }

    public class ProfileLookingUpdateCommand : ProfileLookingVM, IRequest<bool>
    {
    }

    public class ProfileLookingUpdateHandler : IRequestHandler<ProfileLookingUpdateCommand, bool>
    {
        private readonly IProfileLookingApp _app;

        public ProfileLookingUpdateHandler(IProfileLookingApp app)
        {
            _app = app;
        }

        public async Task<bool> Handle(ProfileLookingUpdateCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return await _app.Update(request, cancellationToken);
        }
    }

    #endregion UPDATE

    #region PHOTO-GALLERY

    public class UploadPhotoGalleryCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public byte[] Stream1 { get; set; }
        public byte[] Stream2 { get; set; }
        public byte[] Stream3 { get; set; }
        public byte[] Stream4 { get; set; }
        public byte[] Stream5 { get; set; }
    }

    public class UploadPhotoGalleryHandler : IRequestHandler<UploadPhotoGalleryCommand, bool>
    {
        private readonly IProfileApp _app;
        private readonly StorageHelper storageHelper;

        public UploadPhotoGalleryHandler(IProfileApp app, StorageHelper storageHelper)
        {
            _app = app;
            this.storageHelper = storageHelper;
        }

        public async Task<bool> Handle(UploadPhotoGalleryCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var obj = await _app.GetUser(request.Id);
            if (obj == null) throw new NotificationException("Perfil não encontrado");

            var NewPhotoId1 = Guid.NewGuid().ToString();
            var NewPhotoId2 = Guid.NewGuid().ToString();
            var NewPhotoId3 = Guid.NewGuid().ToString();
            var NewPhotoId4 = Guid.NewGuid().ToString();
            var NewPhotoId5 = Guid.NewGuid().ToString();

            using (var Stream1 = new MemoryStream(request.Stream1))
            {
                await storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoGallery, Stream1, NewPhotoId1);
                await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoGallery, obj.PhotoFileName1);
            }

            using (var Stream2 = new MemoryStream(request.Stream2))
            {
                await storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoGallery, Stream2, NewPhotoId2);
                await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoGallery, obj.PhotoFileName2);
            }

            using (var Stream3 = new MemoryStream(request.Stream3))
            {
                await storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoGallery, Stream3, NewPhotoId3);
                await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoGallery, obj.PhotoFileName3);
            }

            using (var Stream4 = new MemoryStream(request.Stream4))
            {
                await storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoGallery, Stream4, NewPhotoId4);
                await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoGallery, obj.PhotoFileName4);
            }

            using (var Stream5 = new MemoryStream(request.Stream5))
            {
                await storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoGallery, Stream5, NewPhotoId4);
                await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoGallery, obj.PhotoFileName5);
            }

            obj.PhotoFileName1 = NewPhotoId1 + ".jpg";
            obj.PhotoFileName2 = NewPhotoId2 + ".jpg";
            obj.PhotoFileName3 = NewPhotoId3 + ".jpg";
            obj.PhotoFileName4 = NewPhotoId4 + ".jpg";
            obj.PhotoFileName5 = NewPhotoId5 + ".jpg";

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
        private readonly IProfileApp _app;
        private readonly StorageHelper storageHelper;

        public UploadPhotoVaildationHandler(IProfileApp app, StorageHelper storageHelper)
        {
            _app = app;
            this.storageHelper = storageHelper;
        }

        public async Task<bool> Handle(UploadPhotoValidationCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var obj = await _app.GetUser(request.Id);
            if (obj == null || string.IsNullOrEmpty(obj.PhotoFileName1)) throw new NotificationException("Foto para validação não encontrada. Favor, inserir primeiro sua foto de rosto.");

            var NewPhotoId = Guid.NewGuid().ToString();
            //obj.PhotoFaceValidation = NewPhotoId + ".jpg";

            using (var ms = new MemoryStream(request.Stream))
            {
                var validated = await FaceHelper.IsPhotoValid(obj.PhotoFileName1, ms);

                if (validated)
                {
                    await storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoValidation, ms, NewPhotoId);
                    //await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoValidation, obj.PhotoFaceValidation);

                    await _app.Update(obj);
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

    #endregion PHOTO-VALIDATION
}