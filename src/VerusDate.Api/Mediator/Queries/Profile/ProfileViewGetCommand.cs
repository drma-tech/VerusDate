using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static VerusDate.Shared.Helper.ProfileHelper;

namespace VerusDate.Server.Mediator.Queries.Profile
{
    public class ProfileViewGetCommand : IRequest<Shared.Model.Profile>
    {
        public string Id { get; set; }
    }

    public class ProfileViewGetHandler : IRequestHandler<ProfileViewGetCommand, Shared.Model.Profile>
    {
        private readonly IRepository<Shared.Model.Profile> _repo;

        public ProfileViewGetHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Profile>();
        }

        public async Task<Shared.Model.Profile> Handle(ProfileViewGetCommand request, CancellationToken cancellationToken)
        {
            var SQL = new StringBuilder();

            var typeDistance = DistanceType.Km;
            var valueCalDistance = typeDistance == DistanceType.Km ? 1000 : 1609;

            SQL.Append("SELECT ");
            SQL.Append("	PV.Id ");
            //SQL.Append("  , PV.DtInsert ");
            //SQL.Append("  , PV.DtUpdate ");
            //SQL.Append("  , PV.DtTopList ");
            //SQL.Append("  , PV.DtLastLogin ");
            SQL.Append("  , PV.NickName ");
            SQL.Append("  , PV.Description ");
            SQL.Append("  , PV.BirthDate ");
            SQL.Append("  , PV.BiologicalSex ");
            SQL.Append("  , PV.MaritalStatus ");
            SQL.Append("  , PV.Intent ");
            SQL.Append("  , PV.GenderIdentity ");
            SQL.Append("  , PV.SexualOrientation ");
            //SQL.Append("  , PV.Longitude ");
            //SQL.Append("  , PV.Latitude ");
            SQL.Append("  , PV.CountryName ");
            SQL.Append("  , PV.State ");
            SQL.Append("  , PV.City ");
            SQL.Append("  , PV.Height ");
            SQL.Append("  , PV.BodyMass ");
            SQL.Append("  , PV.RaceCategory ");
            SQL.Append("  , PV.Smoke ");
            SQL.Append("  , PV.Drink ");
            SQL.Append("  , PV.Diet ");
            SQL.Append("  , PV.HaveChildren ");
            SQL.Append("  , PV.WantChildren ");
            SQL.Append("  , PV.EducationLevel ");
            SQL.Append("  , PV.CareerCluster ");
            SQL.Append("  , PV.Religion ");
            SQL.Append("  , PV.MoneyPersonality ");
            SQL.Append("  , PV.RelationshipPersonality ");
            SQL.Append("  , PV.MyersBriggsTypeIndicator ");
            SQL.Append("  , PV.Hobbies ");
            SQL.Append("  , PV.PhotoFileName1 ");
            SQL.Append("  , PV.PhotoFileName2 ");
            SQL.Append("  , PV.PhotoFileName3 ");
            SQL.Append("  , PV.PhotoFileName4 ");
            SQL.Append("  , PV.PhotoFileName5 ");
            SQL.Append("  , PV.PhotoFaceValidation ");
            SQL.Append($"  , ROUND(geography::Point(P.Latitude, P.Longitude, 4326).STDistance(geography::Point(PV.Latitude, PV.Longitude, 4326)) / {valueCalDistance}, 1) Distance ");
            SQL.Append("  , CASE ");
            SQL.Append("		WHEN CAST(P.DtLastLogin AS DATE)  = CAST(GETDATE() AS DATE) THEN 0 ");
            SQL.Append("		WHEN CAST(P.DtLastLogin AS DATE) >= CAST(GETDATE()-7 AS DATE) THEN 1 ");
            SQL.Append("		WHEN CAST(P.DtLastLogin AS DATE) >= CAST(GETDATE()-30 AS DATE) THEN 2 ");
            SQL.Append("		ELSE 3 ");
            SQL.Append("	END ActivityStatus ");
            SQL.Append("FROM ");
            SQL.Append("	Profile                  P ");
            SQL.Append("	INNER JOIN Profile       PV ON PV.Id = @IdUser ");
            SQL.Append("WHERE ");
            SQL.Append("    P.ID = @IdUserView");

            return (await _repo.GetByQueryAsync(SQL.ToString(), cancellationToken)).FirstOrDefault();
        }
    }
}