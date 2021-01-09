using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Store
{
    public class StoreExchangeFoodCommand : IRequest<ProfileModel>
    {
        public string Id { get; set; }

        [Required]
        public int QtdDiamond { get; set; }
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
            var obj = await _repo.Get<ProfileModel>(request.Id, request.Id, cancellationToken);

            obj.Gamification.ExchangeFood(request.QtdDiamond);

            return await _repo.Update(obj, request.Id, request.Id, cancellationToken);
        }
    }
}