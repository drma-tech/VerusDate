using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Profile
{
    public class ProfileGetViewCommand : MediatorQuery<ProfileView>
    {
        public ProfileGetViewCommand() : base(CosmosType.Profile)
        {
        }

        public string IdUserView { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override void SetParameters(IQueryCollection query)
        {
            IdUserView = query["id"];
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
            var profile = await _repo.Get<ProfileView>(request.GetId(request.IdUserView), request.IdUserView, cancellationToken);

            profile.Age = profile.BirthDate.GetAge();
            profile.BirthDate = DateTime.MinValue;

            profile.ActivityStatus = Shared.Enum.ActivityStatus.Today;

            if (profile.DtLastLogin >= DateTime.UtcNow.AddDays(-1)) profile.ActivityStatus = Shared.Enum.ActivityStatus.Today;
            else if (profile.DtLastLogin >= DateTime.UtcNow.AddDays(-7)) profile.ActivityStatus = Shared.Enum.ActivityStatus.Week;
            else if (profile.DtLastLogin >= DateTime.UtcNow.AddMonths(-1)) profile.ActivityStatus = Shared.Enum.ActivityStatus.Month;
            else profile.ActivityStatus = Shared.Enum.ActivityStatus.Disabled;

            return profile;
        }
    }
}