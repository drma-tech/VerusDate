using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Queries.Gamification
{
    public class GamificationGetCommand : BaseCommandQuery<GamificationVM> { }

    public class GamificationGetHandler : IRequestHandler<GamificationGetCommand, GamificationVM>
    {
        private readonly IRepository _repo;

        public GamificationGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<GamificationVM> Handle(GamificationGetCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<GamificationVM>(request.IdUser);

            if (obj == null)
            {
                obj = new GamificationVM() { IdUser = request.IdUser };
                await _repo.Insert(obj);
            }

            return obj;
        }
    }
}