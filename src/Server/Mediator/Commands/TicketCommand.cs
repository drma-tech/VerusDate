using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Commands
{
    #region INSERT

    public class TicketInsertCommand : TicketVM, IRequest<bool>
    {
    }

    public class TicketInsertChatHandler : IRequestHandler<TicketInsertCommand, bool>
    {
        private readonly ITicketApp _app;

        public TicketInsertChatHandler(ITicketApp app)
        {
            _app = app;
        }

        public async Task<bool> Handle(TicketInsertCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return await _app.Add(request);
        }
    }

    #endregion INSERT

    #region VOTE

    public class TicketVoteCommand : IRequest<bool>
    {
        public string IdTicket { get; set; }
        public string IdUser { get; set; }
    }

    public class TicketVoteHandler : IRequestHandler<TicketVoteCommand, bool>
    {
        private readonly ITicketApp _app;

        public TicketVoteHandler(ITicketApp app)
        {
            _app = app;
        }

        public async Task<bool> Handle(TicketVoteCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return await _app.Vote(request.IdTicket, request.IdUser, cancellationToken);
        }
    }

    #endregion VOTE
}