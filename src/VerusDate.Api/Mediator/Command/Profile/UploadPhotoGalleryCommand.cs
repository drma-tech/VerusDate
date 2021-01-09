using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Helper;

namespace VerusDate.Server.Mediator.Commands.Profile
{
    public class UploadPhotoGalleryCommand : IRequest<bool>
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
            var obj = await _repo.Get<Shared.Model.Profile.Profile>(request.Id, request.Id, cancellationToken);
            if (obj == null) throw new NotificationException("Perfil não encontrado");

            foreach (var bytes in request.Streams)
            {
                using (var stream = new MemoryStream(bytes))
                {
                    var photoName = Guid.NewGuid().ToString();

                    await storageHelper.UploadPhoto(ImageHelper.PhotoType.PhotoGallery, stream, photoName, cancellationToken);
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