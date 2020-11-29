using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Commands.Ticket
{
    public class TicketInsertCommand : TicketVM, IBaseCommand<bool> { }

    public class TicketInsertChatHandler : IRequestHandler<TicketInsertCommand, bool>
    {
        private readonly IRepository _repo;

        public TicketInsertChatHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(TicketInsertCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Insert(request);
        }
    }
}