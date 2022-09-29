using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Api.Mediator;
using VerusDate.Shared.Core;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Mediator.Commands.Profile
{
    public class DeletePhotoGalleryCommand : MediatorQuery<bool>
    {
        public DeletePhotoGalleryCommand() : base(CosmosType.Profile)
        {
        }

        public string IdPhoto { get; set; }

        public override void SetParameters(IQueryCollection query)
        {
            IdPhoto = query["IdPhoto"];
        }
    }

    public class DeletePhotoGalleryHandler : IRequestHandler<DeletePhotoGalleryCommand, bool>
    {
        private readonly IRepository _repo;
        private readonly StorageHelper storageHelper;

        public DeletePhotoGalleryHandler(IRepository repo, StorageHelper storageHelper)
        {
            _repo = repo;
            this.storageHelper = storageHelper;
        }

        public async Task<bool> Handle(DeletePhotoGalleryCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<ProfileModel>(request.Id, request.IdLoggedUser, cancellationToken);
            if (obj == null) throw new NotificationException("Perfil não encontrado");

            await storageHelper.DeletePhoto(ImageHelper.PhotoType.PhotoGallery, request.IdPhoto, cancellationToken);

            obj.Photo.RemovePhotoGallery(request.IdPhoto);

            obj.UpdatePhoto(obj.Photo);

            await _repo.Update(obj, cancellationToken);

            return true;
        }
    }
}