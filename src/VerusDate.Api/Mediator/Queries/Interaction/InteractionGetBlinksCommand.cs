using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.ModelQuery;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetBlinksCommand : IRequest<IEnumerable<Shared.ModelQuery.ProfileBasic>> { }

    public class InteractionGetBlinksHandler : IRequestHandler<InteractionGetBlinksCommand, IEnumerable<ProfileBasic>>
    {
        //private readonly IRepository<ProfileBasic> _repo;

        public InteractionGetBlinksHandler(IRepositoryFactory factory)
        {
            //_repo = factory.RepositoryOf<ProfileBasic>();
        }

        public async Task<IEnumerable<ProfileBasic>> Handle(InteractionGetBlinksCommand request, CancellationToken cancellationToken)
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

            //return await _repo.GetByQueryAsync(SQL.ToString(), cancellationToken);
            return null;
        }
    }
}