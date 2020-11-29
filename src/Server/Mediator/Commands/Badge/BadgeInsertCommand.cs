using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Commands.Badge
{
    public class BadgeInsertCommand : BadgeVM, IBaseCommand<bool> { }

    public class BadgeInsertHandler : IRequestHandler<BadgeInsertCommand, bool>
    {
        private readonly IRepository _repo;

        public BadgeInsertHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(BadgeInsertCommand request, CancellationToken cancellationToken)
        {
            await _repo.Insert(request);
            return true;
        }
    }
}