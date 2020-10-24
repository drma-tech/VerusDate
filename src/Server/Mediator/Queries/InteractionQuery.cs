using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries
{
    #region GET

    public class InteractionGetCommand : IRequest<InteractionVM>
    {
        public string IdUser { get; set; }
        public string IdUserInteraction { get; set; }
    }

    public class InteractionGetHandler : IRequestHandler<InteractionGetCommand, InteractionVM>
    {
        private readonly IInteractionApp _app;

        public InteractionGetHandler(IInteractionApp app)
        {
            _app = app;
        }

        public async Task<InteractionVM> Handle(InteractionGetCommand request, CancellationToken cancellationToken)
        {
            return await _app.Get(request.IdUser, request.IdUserInteraction, cancellationToken);
        }
    }

    #endregion GET

    #region GET_LIST

    public class InteractionGetListCommand : IRequest<IEnumerable<InteractionVM>>
    {
        public string IdUser { get; set; }
    }

    public class InteractionGetListHandler : IRequestHandler<InteractionGetListCommand, IEnumerable<InteractionVM>>
    {
        private readonly IInteractionApp _app;

        public InteractionGetListHandler(IInteractionApp app)
        {
            _app = app;
        }

        public async Task<IEnumerable<InteractionVM>> Handle(InteractionGetListCommand request, CancellationToken cancellationToken)
        {
            return await _app.GetList(request.IdUser, cancellationToken);
        }
    }

    #endregion GET_LIST

    #region GET_LIKES

    public class InteractionGetLikesCommand : IRequest<IEnumerable<ProfileBasicVM>>
    {
        public string IdUser { get; set; }
    }

    public class InteractionGetLikesHandler : IRequestHandler<InteractionGetLikesCommand, IEnumerable<ProfileBasicVM>>
    {
        private readonly IInteractionApp _app;

        public InteractionGetLikesHandler(IInteractionApp app)
        {
            _app = app;
        }

        public async Task<IEnumerable<ProfileBasicVM>> Handle(InteractionGetLikesCommand request, CancellationToken cancellationToken)
        {
            return await _app.GetLikes(request.IdUser, cancellationToken);
        }
    }

    #endregion GET_LIKES

    #region GET_BLINKS

    public class InteractionGetBlinksCommand : IRequest<IEnumerable<ProfileBasicVM>>
    {
        public string IdUser { get; set; }
    }

    public class InteractionGetBlinksHandler : IRequestHandler<InteractionGetBlinksCommand, IEnumerable<ProfileBasicVM>>
    {
        private readonly IInteractionApp _app;

        public InteractionGetBlinksHandler(IInteractionApp app)
        {
            _app = app;
        }

        public async Task<IEnumerable<ProfileBasicVM>> Handle(InteractionGetBlinksCommand request, CancellationToken cancellationToken)
        {
            return await _app.GetLikes(request.IdUser, cancellationToken);
        }
    }

    #endregion GET_BLINKS

    #region GET_NEW_MATCHES

    public class InteractionGetNewMatchesCommand : IRequest<IEnumerable<ProfileBasicVM>>
    {
        public string IdUser { get; set; }
    }

    public class InteractionGetNewMatchesHandler : IRequestHandler<InteractionGetNewMatchesCommand, IEnumerable<ProfileBasicVM>>
    {
        private readonly IInteractionApp _app;

        public InteractionGetNewMatchesHandler(IInteractionApp app)
        {
            _app = app;
        }

        public async Task<IEnumerable<ProfileBasicVM>> Handle(InteractionGetNewMatchesCommand request, CancellationToken cancellationToken)
        {
            return await _app.GetNewMatches(request.IdUser, cancellationToken);
        }
    }

    #endregion GET_NEW_MATCHES

    #region GET_CHAT_LIST

    public class InteractionGetChatListCommand : IRequest<IEnumerable<ProfileChatListVM>>
    {
        public string IdUser { get; set; }
    }

    public class InteractionGetChatListHandler : IRequestHandler<InteractionGetChatListCommand, IEnumerable<ProfileChatListVM>>
    {
        private readonly IInteractionApp _app;

        public InteractionGetChatListHandler(IInteractionApp app)
        {
            _app = app;
        }

        public async Task<IEnumerable<ProfileChatListVM>> Handle(InteractionGetChatListCommand request, CancellationToken cancellationToken)
        {
            return await _app.GetChatList(request.IdUser, cancellationToken);
        }
    }

    #endregion GET_CHAT_LIST
}