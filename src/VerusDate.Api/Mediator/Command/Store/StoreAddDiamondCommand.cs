using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Store
{
    public class StoreAddDiamondCommand : CosmosBase, IRequest<bool>
    {
        public StoreAddDiamondCommand() : base(CosmosType.Profile)
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

    public class StoreAddDiamondHandler : IRequestHandler<StoreAddDiamondCommand, bool>
    {
        private readonly IRepository _repo;

        public StoreAddDiamondHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(StoreAddDiamondCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<ProfileModel>(request.Id, request.Key, cancellationToken);

            obj.Gamification.AddDiamond(request.QtdDiamond);

            return await _repo.Update(obj, cancellationToken);
        }
    }
}