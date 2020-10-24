using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries
{
    #region GET

    public class GamificationGetCommand : IRequest<GamificationVM>
    {
        public string IdUser { get; set; }
    }

    public class GamificationGetHandler : IRequestHandler<GamificationGetCommand, GamificationVM>
    {
        private readonly IGamificationApp _app;

        public GamificationGetHandler(IGamificationApp app)
        {
            _app = app;
        }

        public async Task<GamificationVM> Handle(GamificationGetCommand request, CancellationToken cancellationToken)
        {
            return await _app.Get(request.IdUser, cancellationToken);
        }
    }

    #endregion GET
}