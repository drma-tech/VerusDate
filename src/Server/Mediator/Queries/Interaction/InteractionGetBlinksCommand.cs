using MediatR;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries.Interaction
{
    public class InteractionGetBlinksCommand : BaseCommandQuery<IEnumerable<ProfileBasicVM>> { }

    public class InteractionGetBlinksHandler : IRequestHandler<InteractionGetBlinksCommand, IEnumerable<ProfileBasicVM>>
    {
        private readonly IRepository _repo;

        public InteractionGetBlinksHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProfileBasicVM>> Handle(InteractionGetBlinksCommand request, CancellationToken cancellationToken)
        {
            var SQL = new StringBuilder();

            SQL.Append("SELECT ");
            SQL.Append("	I.Id ");
            SQL.Append("  , P.NickName ");
            SQL.Append("  , P.BirthDate ");
            SQL.Append("  , PP.PhotoFace ");
            SQL.Append("FROM ");
            SQL.Append("	Interaction              I ");
            SQL.Append("	INNER JOIN profile       P  ON I.Id = P.Id ");
            SQL.Append("	INNER JOIN ProfilePhotos PP ON I.Id = PP.Id ");
            SQL.Append("WHERE ");
            SQL.Append("	I.IdUserInteraction   = @IdUser ");
            SQL.Append("	AND I.Blinked         = 1 ");
            SQL.Append("	AND I.Matched         = 0");

            return await _repo.Query<ProfileBasicVM>(SQL, request, cancellationToken);
        }
    }
}