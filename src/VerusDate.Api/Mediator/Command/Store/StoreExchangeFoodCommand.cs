using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Command.Store
{
    public class StoreExchangeFoodCommand : Shared.Model.Gamification, IRequest<Shared.Model.Gamification>
    {
        [Required]
        public int QtdDiamond { get; set; }
    }

    public class StoreExchangeFoodHandler : IRequestHandler<StoreExchangeFoodCommand, Shared.Model.Gamification>
    {
        private readonly IRepository<Shared.Model.Gamification> _repo;

        public StoreExchangeFoodHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Gamification>();
        }

        public async Task<Shared.Model.Gamification> Handle(StoreExchangeFoodCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);

            obj.ExchangeFood(request.QtdDiamond);

            return await _repo.UpdateAsync(obj, cancellationToken);
        }
    }
}