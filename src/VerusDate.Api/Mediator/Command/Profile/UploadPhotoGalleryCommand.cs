using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Mediator.Commands.Profile
{
    public class UploadPhotoGalleryCommand : CosmosBase, IRequest<ProfileModel>
    {
        public UploadPhotoGalleryCommand() : base(CosmosType.Profile)
        {
        }

        public List<byte[]> Streams { get; set; }

        public override void SetIds(string IdLoggedUser)
        {
            this.SetId(IdLoggedUser);
            this.SetPartitionKey(IdLoggedUser);
        }
    }

    public class UploadPhotoGalleryHandler : IRequestHandler<UploadPhotoGalleryCommand, ProfileModel>
    {
        private readonly IRepository _repo;
        private readonly StorageHelper storageHelper;

        public UploadPhotoGalleryHandler(IRepository repo, StorageHelper storageHelper)
        {
            _repo = repo;
            this.storageHelper = storageHelper;
        }

        public async Task<ProfileModel> Handle(UploadPhotoGalleryCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<ProfileModel>(request.Id, request.Key, cancellationToken);
            if (obj == null) throw new NotificationException("Perfil não encontrado");

            //if (obj.Photo != null && obj.Photo.Gallery.Any())
            //{
            //    foreach (var item in obj.Photo.Gallery)
            //    {
            //        //se manter a foto com o mesmo id, o cache do browser não vai atualizar a foto
            //        await storageHelper.DeletePhoto(ImageHelper.PhotoType.PhotoGallery, item, cancellationToken);
            //    }
            //}

            //obj.Photo.Gallery = Array.Empty<string>();

            if (obj.Photo == null)
            {
                obj.Photo = new ProfilePhotoModel();
            }

            foreach (var bytes in request.Streams)
            {
                using (var stream = new MemoryStream(bytes))
                {
                    var photoName = Guid.NewGuid().ToString() + ".jpg";

                    await storageHelper.UploadPhoto(ImageHelper.PhotoType.PhotoGallery, stream, photoName, cancellationToken);

                    obj.Photo.Gallery = obj.Photo.Gallery.Concat(new string[] { photoName }).ToArray();

                    obj.UpdatePhoto(obj.Photo);
                }
            }

            return await _repo.Update(obj, cancellationToken);
        }
    }
}