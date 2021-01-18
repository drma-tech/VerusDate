using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Support
{
    public class TicketInsertCommand : TicketModel, IRequest<TicketModel> { }

    public class TicketInsertHandler : IRequestHandler<TicketInsertCommand, TicketModel>
    {
        private readonly IRepository _repo;

        public TicketInsertHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<TicketModel> Handle(TicketInsertCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Add(request, cancellationToken);
        }
    }
}