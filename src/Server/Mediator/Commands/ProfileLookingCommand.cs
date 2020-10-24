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

    public class ProfileLookingAddCommand : ProfileLookingVM, IRequest<bool>
    {
    }

    public class ProfileLookingAddHandler : IRequestHandler<ProfileLookingAddCommand, bool>
    {
        private readonly IProfileLookingApp _app;
        private readonly IProfileValidationApp _profileValidationApp;
        private readonly IGamificationApp _gamificationApp;

        public ProfileLookingAddHandler(IProfileLookingApp app, IProfileValidationApp profileValidationApp, IGamificationApp gamificationApp)
        {
            _app = app;
            _profileValidationApp = profileValidationApp;
            _gamificationApp = gamificationApp;
        }

        public async Task<bool> Handle(ProfileLookingAddCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var obj = await _profileValidationApp.Get(request.Id, cancellationToken);

            if (!obj.ProfileCriteria.HasValue)
            {
                await _gamificationApp.AddXP(request.Id, EventAddXP.ValidateProfileCriteria, cancellationToken);
            }

            await _profileValidationApp.ValidateProfileCriteria(request.Id, true, cancellationToken);

            return await _app.Add(request, cancellationToken);
        }
    }

    #endregion ADD

    #region UPDATE

    public class ProfileLookingUpdateCommand : ProfileLookingVM, IRequest<bool>
    {
    }

    public class ProfileLookingUpdateHandler : IRequestHandler<ProfileLookingUpdateCommand, bool>
    {
        private readonly IProfileLookingApp _app;

        public ProfileLookingUpdateHandler(IProfileLookingApp app)
        {
            _app = app;
        }

        public async Task<bool> Handle(ProfileLookingUpdateCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return await _app.Update(request, cancellationToken);
        }
    }

    #endregion UPDATE
}