using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Commands.Gamification
{
    public class GamificationExchangeFoodCommand : IBaseCommand<bool>
    {
        public string IdUser { get; set; }

        /// <summary>
        /// Quatidade de diamantes desejados para a troca
        /// </summary>
        [Required]
        public int QtdDiamond { get; set; }
    }

    public class GamificationExchangeFoodHandler : IRequestHandler<GamificationExchangeFoodCommand, bool>
    {
        private readonly IRepository _repo;

        public GamificationExchangeFoodHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(GamificationExchangeFoodCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<GamificationVM>(request.IdUser);

            obj.ExchangeFood(request.QtdDiamond);

            return await _repo.Update(obj);
        }
    }
}