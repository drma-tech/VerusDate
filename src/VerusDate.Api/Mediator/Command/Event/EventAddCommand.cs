using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class EventAddCommand : EventModel, IRequest<EventModel>
    { }

    public class EventAddHandler : IRequestHandler<EventAddCommand, EventModel>
    {
        private readonly IRepository _repo;

        public EventAddHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<EventModel> Handle(EventAddCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Add(request, cancellationToken);
        }
    }
}