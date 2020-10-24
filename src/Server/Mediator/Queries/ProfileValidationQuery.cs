using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries
{
    #region GET

    public class ProfileValidationGetCommand : IRequest<ProfileValidationVM>
    {
        public string IdUser { get; set; }
    }

    public class ProfileValidationGetHandler : IRequestHandler<ProfileValidationGetCommand, ProfileValidationVM>
    {
        private readonly IProfileValidationApp _app;

        public ProfileValidationGetHandler(IProfileValidationApp app)
        {
            _app = app;
        }

        public async Task<ProfileValidationVM> Handle(ProfileValidationGetCommand request, CancellationToken cancellationToken)
        {
            return await _app.Get(request.IdUser, cancellationToken);
        }
    }

    #endregion GET
}