using MediatR;
using Microsoft.Azure.Cosmos;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Store
{
    public class StoreExchangeFoodCommand : CosmosBase, IRequest<ProfileModel>
    {
        public StoreExchangeFoodCommand() : base(CosmosType.Profile)
        {
        }

        [Required]
        public int QtdDiamond { get; set; }

        public override void SetIds(string IdLoggedUser)
        {
            this.SetId(IdLoggedUser);
            this.SetPartitionKey(IdLoggedUser);
        }
    }

    public class StoreExchangeFoodHandler : IRequestHandler<StoreExchangeFoodCommand, ProfileModel>
    {
        private readonly IRepository _repo;

        public StoreExchangeFoodHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProfileModel> Handle(StoreExchangeFoodCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<ProfileModel>(request.Id, new PartitionKey(request.Key), cancellationToken);

            obj.Gamification.ExchangeFood(request.QtdDiamond);

            return await _repo.Update(obj, cancellationToken);
        }
    }
}