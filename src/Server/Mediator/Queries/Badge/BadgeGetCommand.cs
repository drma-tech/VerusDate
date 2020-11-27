using Dapper.FluentMap;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Mapper;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries.Badge
{
    public class BadgeGetCommand : BaseCommandQuery<BadgeVM> { }

    public class BadgeGetHandler : IRequestHandler<BadgeGetCommand, BadgeVM>
    {
        private readonly IRepository _repo;

        public BadgeGetHandler(IRepository repo)
        {
            _repo = repo;

            //FluentMapper.Initialize(cfg => cfg.AddMap(new BadgeMapper()));
        }

        public async Task<BadgeVM> Handle(BadgeGetCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<BadgeVM>(request.IdUser);

            if (obj == null)
            {
                obj = new BadgeVM { Id = request.IdUser };
                await _repo.Insert(obj);
            }

            return obj;
        }
    }
}