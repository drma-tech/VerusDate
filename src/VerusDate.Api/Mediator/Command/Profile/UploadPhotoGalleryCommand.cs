using MediatR;
using Microsoft.Azure.CosmosRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
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
        private readonly IRepository<Shared.Model.Profile.Profile> _repo;
        private readonly StorageHelper storageHelper;

        public UploadPhotoGalleryHandler(IRepositoryFactory factory, StorageHelper storageHelper)
        {
            _repo = factory.RepositoryOf<Shared.Model.Profile.Profile>();
            this.storageHelper = storageHelper;
        }

        public async Task<bool> Handle(UploadPhotoGalleryCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);
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