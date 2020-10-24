using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries
{
    #region GET

    public class ProfileLookingGetCommand : IRequest<ProfileLookingVM>
    {
        public string IdUser { get; set; }
    }

    public class ProfileLookingGetHandler : IRequestHandler<ProfileLookingGetCommand, ProfileLookingVM>
    {
        private readonly IProfileLookingApp _app;

        public ProfileLookingGetHandler(IProfileLookingApp app)
        {
            _app = app;
        }

        public async Task<ProfileLookingVM> Handle(ProfileLookingGetCommand request, CancellationToken cancellationToken)
        {
            return await _app.Get(request.IdUser, cancellationToken);
        }
    }

    #endregion GET
}