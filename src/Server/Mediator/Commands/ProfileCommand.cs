using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Commands
{
    #region ADD

    public class ProfileAddCommand : ProfileUserVM, IRequest<bool>
    {
    }

    public class ProfileAddHandler : IRequestHandler<ProfileAddCommand, bool>
    {
        private readonly IProfileApp _app;
        private readonly IProfileValidationApp _profileValidationApp;
        private readonly IGamificationApp _gamificationApp;

        public ProfileAddHandler(IProfileApp app, IProfileValidationApp profileValidationApp, IGamificationApp gamificationApp)
        {
            _app = app;
            _profileValidationApp = profileValidationApp;
            _gamificationApp = gamificationApp;
        }

        public async Task<bool> Handle(ProfileAddCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var pv = await _profileValidationApp.Get(request.Id, cancellationToken);

            if (!pv.ProfileData.HasValue)
            {
                await _gamificationApp.AddXP(request.Id, EventAddXP.ValidateProfileData, cancellationToken);
            }

            await _profileValidationApp.ValidateProfileData(request.Id, true, cancellationToken);

            return await _app.Add(request, cancellationToken);
        }
    }

    #endregion ADD

    #region UPDATE

    public class ProfileUpdateCommand : ProfileUserVM, IRequest<bool>
    {
    }

    public class ProfileUpdateHandler : IRequestHandler<ProfileUpdateCommand, bool>
    {
        private readonly IProfileApp _app;
        private readonly IGamificationApp _gamificationApp;

        public ProfileUpdateHandler(IProfileApp app, IGamificationApp gamificationApp)
        {
            _app = app;
            _gamificationApp = gamificationApp;
        }

        public async Task<bool> Handle(ProfileUpdateCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            await _gamificationApp.RemoveXP(request.Id, EventRemoveXP.UpdateProfile, cancellationToken);

            return await _app.Update(request, cancellationToken);
        }
    }

    #endregion UPDATE
}