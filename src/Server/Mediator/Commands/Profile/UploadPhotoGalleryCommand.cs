using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Helper;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Helper;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Commands.Profile
{
    public class UploadPhotoGalleryCommand : IBaseCommand<bool>
    {
        public string Id { get; set; }
        public List<byte[]> Streams { get; set; }
    }

    public class UploadPhotoGalleryHandler : IRequestHandler<UploadPhotoGalleryCommand, bool>
    {
        private readonly IRepository _repo;
        private readonly StorageHelper storageHelper;

        public UploadPhotoGalleryHandler(IRepository repo, StorageHelper storageHelper)
        {
            _repo = repo;
            this.storageHelper = storageHelper;
        }

        public async Task<bool> Handle(UploadPhotoGalleryCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<ProfileVM>(request.Id);
            if (obj == null) throw new NotificationException("Perfil não encontrado");

            foreach (var bytes in request.Streams)
            {
                using (var stream = new MemoryStream(bytes))
                {
                    var photoName = Guid.NewGuid().ToString();

                    await storageHelper.UploadPhoto(StorageHelper.PhotoType.PhotoGallery, stream, photoName);
                    //TODO: deletar fotos antigas
                    //await storageHelper.DeletePhoto(StorageHelper.PhotoType.PhotoGallery, obj.PhotoFileName1);

                    //obj.PhotoFileNames += photoName + ".jpg";
                }
            }

            return true;
            //return await _app.Update(obj, cancellationToken);
        }
    }
}