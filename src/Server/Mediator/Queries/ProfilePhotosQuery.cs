using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries
{
    #region GET

    public class ProfilePhotosGetCommand : IRequest<ProfilePhotosVM>
    {
        public string IdUser { get; set; }
    }

    public class ProfilePhotosGetHandler : IRequestHandler<ProfilePhotosGetCommand, ProfilePhotosVM>
    {
        private readonly IProfilePhotosApp _app;

        public ProfilePhotosGetHandler(IProfilePhotosApp app)
        {
            _app = app;
        }

        public async Task<ProfilePhotosVM> Handle(ProfilePhotosGetCommand request, CancellationToken cancellationToken)
        {
            return await _app.Get(request.IdUser, cancellationToken);
        }
    }

    #endregion GET
}