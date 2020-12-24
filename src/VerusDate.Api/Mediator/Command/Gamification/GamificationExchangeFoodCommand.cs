using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Command.Gamification
{
    public class GamificationExchangeFoodCommand : Shared.Model.Gamification, IRequest<Shared.Model.Gamification>
    {
        [Required]
        public int QtdDiamond { get; set; }
    }

    public class GamificationExchangeFoodHandler : IRequestHandler<GamificationExchangeFoodCommand, Shared.Model.Gamification>
    {
        private readonly IRepository<Shared.Model.Gamification> _repo;

        public GamificationExchangeFoodHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Gamification>();
        }

        public async Task<Shared.Model.Gamification> Handle(GamificationExchangeFoodCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);

            obj.ExchangeFood(request.QtdDiamond);

            return await _repo.UpdateAsync(obj, cancellationToken);
        }
    }
}