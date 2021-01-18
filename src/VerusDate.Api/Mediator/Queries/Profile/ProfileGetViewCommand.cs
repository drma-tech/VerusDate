using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Profile
{
    public class ProfileGetViewCommand : MediatorQuery<ProfileView>
    {
        public string IdUserView { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override void SetParameters(IQueryCollection query)
        {
            IdUserView = query["id"];
            Latitude = double.Parse(query["latitude"]);
            Longitude = double.Parse(query["longitude"]);
        }
    }

    public class ProfileGetViewHandler : IRequestHandler<ProfileGetViewCommand, ProfileView>
    {
        private readonly IRepository _repo;

        public ProfileGetViewHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProfileView> Handle(ProfileGetViewCommand request, CancellationToken cancellationToken)
        {
            var result = await _repo.Get<ProfileView>(request.IdUserView, new PartitionKey(request.IdUserView), cancellationToken);

            result.ActivityStatus = result.GetActivityStatus();
            result.Distance = result.GetDistance(request.Latitude, request.Longitude);

            result.ProtectSensitiveData();

            return result;
        }
    }
}