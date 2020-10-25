using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries
{
    #region GET

    public class GlobalInteractionsGetCommand : IRequest<GlobalInteractionsVM>
    {
        public string Id { get; set; }
    }

    public class GlobalInteractionsGetHandler : IRequestHandler<GlobalInteractionsGetCommand, GlobalInteractionsVM>
    {
        private readonly IGlobalInteractionsApp _app;

        public GlobalInteractionsGetHandler(IGlobalInteractionsApp app)
        {
            _app = app;
        }

        public async Task<GlobalInteractionsVM> Handle(GlobalInteractionsGetCommand request, CancellationToken cancellationToken)
        {
            return await _app.Get(request.Id);
        }
    }

    #endregion GET
}