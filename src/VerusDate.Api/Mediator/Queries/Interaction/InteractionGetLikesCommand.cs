using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetLikesCommand : IRequest<IEnumerable<Shared.ModelQuery.ProfileBasic>> { }

    public class InteractionGetLikesHandler : IRequestHandler<InteractionGetLikesCommand, IEnumerable<Shared.ModelQuery.ProfileBasic>>
    {
        //private readonly IRepository<Shared.ModelQuery.ProfileBasic> _repo;

        public InteractionGetLikesHandler(IRepositoryFactory factory)
        {
            //_repo = factory.RepositoryOf<Shared.ModelQuery.ProfileBasic>();
        }

        public async Task<IEnumerable<Shared.ModelQuery.ProfileBasic>> Handle(InteractionGetLikesCommand request, CancellationToken cancellationToken)
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
            SQL.Append("	I.IdUserInteraction = @IdUser ");
            SQL.Append("	AND I.Liked         = 1 ");
            SQL.Append("	AND I.Matched       = 0");

            //return await _repo.GetByQueryAsync(SQL.ToString(), cancellationToken);
            return null;
        }
    }
}