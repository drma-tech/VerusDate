using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries
{
    #region GET_LIST

    public class TicketGetListCommand : IRequest<IEnumerable<TicketVM>>
    {
    }

    public class TicketGetListHandler : IRequestHandler<TicketGetListCommand, IEnumerable<TicketVM>>
    {
        private readonly ITicketApp _app;

        public TicketGetListHandler(ITicketApp app)
        {
            _app = app;
        }

        public async Task<IEnumerable<TicketVM>> Handle(TicketGetListCommand request, CancellationToken cancellationToken)
        {
            return await _app.GetList(cancellationToken);
        }
    }

    #endregion GET_LIST

    #region GET_MY_VOTES

    public class TicketGetMyVotesCommand : IRequest<IEnumerable<TicketVoteVM>>
    {
        public string IdUser { get; set; }
    }

    public class TicketGetMyVotesHandler : IRequestHandler<TicketGetMyVotesCommand, IEnumerable<TicketVoteVM>>
    {
        private readonly ITicketApp _app;

        public TicketGetMyVotesHandler(ITicketApp app)
        {
            _app = app;
        }

        public async Task<IEnumerable<TicketVoteVM>> Handle(TicketGetMyVotesCommand request, CancellationToken cancellationToken)
        {
            return await _app.GetMyVotes(request.IdUser, cancellationToken);
        }
    }

    #endregion GET_MY_VOTES
}