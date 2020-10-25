using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries
{
    #region GET

    public class BadgeGetCommand : IRequest<BadgeVM>
    {
        public string IdUser { get; set; }
    }

    public class BadgeGetHandler : IRequestHandler<BadgeGetCommand, BadgeVM>
    {
        private readonly IBadgeApp _app;

        public BadgeGetHandler(IBadgeApp app)
        {
            _app = app;
        }

        public async Task<BadgeVM> Handle(BadgeGetCommand request, CancellationToken cancellationToken)
        {
            return await _app.Get(request.IdUser);
        }
    }

    #endregion GET
}