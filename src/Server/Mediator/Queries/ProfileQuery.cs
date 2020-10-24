using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries
{
    #region GET_USER

    public class ProfileUserGetCommand : IRequest<ProfileUserVM>
    {
        public string IdUser { get; set; }
    }

    public class ProfileUserGetHandler : IRequestHandler<ProfileUserGetCommand, ProfileUserVM>
    {
        private readonly IProfileApp _app;

        public ProfileUserGetHandler(IProfileApp app)
        {
            _app = app;
        }

        public async Task<ProfileUserVM> Handle(ProfileUserGetCommand request, CancellationToken cancellationToken)
        {
            return await _app.GetUser(request.IdUser, cancellationToken);
        }
    }

    #endregion GET_USER

    #region GET_VIEW

    public class ProfileViewGetCommand : IRequest<ProfileViewVM>
    {
        public string IdUser { get; set; }
        public string IdUserView { get; set; }
    }

    public class ProfileViewGetHandler : IRequestHandler<ProfileViewGetCommand, ProfileViewVM>
    {
        private readonly IProfileApp _app;

        public ProfileViewGetHandler(IProfileApp app)
        {
            _app = app;
        }

        public async Task<ProfileViewVM> Handle(ProfileViewGetCommand request, CancellationToken cancellationToken)
        {
            return await _app.GetView(request.IdUser, request.IdUserView, cancellationToken);
        }
    }

    #endregion GET_VIEW

    #region LIST_MATCH

    public class ProfileListMatchCommand : IRequest<IEnumerable<ProfileViewVM>>
    {
        public string IdUser { get; set; }
    }

    public class ProfileListAllHandler : IRequestHandler<ProfileListMatchCommand, IEnumerable<ProfileViewVM>>
    {
        private readonly IProfileApp _app;
        private readonly IProfileLookingApp _profileLookingApp;

        public ProfileListAllHandler(IProfileApp app, IProfileLookingApp profileLookingApp)
        {
            _app = app;
            _profileLookingApp = profileLookingApp;
        }

        public async Task<IEnumerable<ProfileViewVM>> Handle(ProfileListMatchCommand request, CancellationToken cancellationToken)
        {
            var looking = await _profileLookingApp.Get(request.IdUser, cancellationToken);

            return await _app.GetListMatch(looking, cancellationToken);
        }
    }

    #endregion LIST_MATCH

    #region LIST_SEARCH

    public class ProfileListSearchCommand : IRequest<IEnumerable<ProfileViewVM>>
    {
        public string IdUser { get; set; }
    }

    public class ProfileListSearchHandler : IRequestHandler<ProfileListSearchCommand, IEnumerable<ProfileViewVM>>
    {
        private readonly IProfileApp _app;
        private readonly IProfileLookingApp _profileLookingApp;

        public ProfileListSearchHandler(IProfileApp app, IProfileLookingApp profileLookingApp)
        {
            _app = app;
            _profileLookingApp = profileLookingApp;
        }

        public async Task<IEnumerable<ProfileViewVM>> Handle(ProfileListSearchCommand request, CancellationToken cancellationToken)
        {
            var looking = await _profileLookingApp.Get(request.IdUser, cancellationToken);

            return await _app.GetListSearch(looking, cancellationToken);
        }
    }

    #endregion LIST_SEARCH
}