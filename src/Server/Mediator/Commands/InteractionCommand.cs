using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;

namespace VerusDate.Server.Mediator.Commands
{
    #region BLINK

    public class InteractionBlinkCommand : IRequest<bool>
    {
        public string IdUser { get; set; }
        public string IdUserInteraction { get; set; }
    }

    public class InteractionBlinkHandler : IRequestHandler<InteractionBlinkCommand, bool>
    {
        private readonly IInteractionApp _app;
        private readonly IGamificationApp _gamificationApp;

        public InteractionBlinkHandler(IInteractionApp app, IGamificationApp gamificationApp)
        {
            _app = app;
            _gamificationApp = gamificationApp;
        }

        public async Task<bool> Handle(InteractionBlinkCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            await _gamificationApp.RemoveDiamond(request.IdUser, 1, null, cancellationToken);

            return await _app.Blink(request.IdUser, request.IdUserInteraction, cancellationToken);
        }
    }

    #endregion BLINK

    #region BLOCK

    public class InteractionBlockCommand : IRequest<bool>
    {
        public string IdUser { get; set; }
        public string IdUserInteraction { get; set; }
    }

    public class InteractionBlockHandler : IRequestHandler<InteractionBlockCommand, bool>
    {
        private readonly IInteractionApp _app;

        public InteractionBlockHandler(IInteractionApp app)
        {
            _app = app;
        }

        public async Task<bool> Handle(InteractionBlockCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return await _app.Block(request.IdUser, request.IdUserInteraction, cancellationToken);
        }
    }

    #endregion BLOCK

    #region DESLIKE

    public class InteractionDeslikeCommand : IRequest<bool>
    {
        public string IdUser { get; set; }
        public string IdUserInteraction { get; set; }
    }

    public class InteractionDeslikeHandler : IRequestHandler<InteractionDeslikeCommand, bool>
    {
        private readonly IInteractionApp _app;

        public InteractionDeslikeHandler(IInteractionApp app)
        {
            _app = app;
        }

        public async Task<bool> Handle(InteractionDeslikeCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return await _app.Deslike(request.IdUser, request.IdUserInteraction, cancellationToken);
        }
    }

    #endregion DESLIKE

    #region LIKE

    public class InteractionLikeCommand : IRequest<bool>
    {
        public string IdUser { get; set; }
        public string IdUserInteraction { get; set; }
    }

    public class InteractionLikeHandler : IRequestHandler<InteractionLikeCommand, bool>
    {
        private readonly IInteractionApp _app;
        private readonly IGamificationApp _gamificationApp;

        public InteractionLikeHandler(IInteractionApp app, IGamificationApp gamificationApp)
        {
            _app = app;
            _gamificationApp = gamificationApp;
        }

        public async Task<bool> Handle(InteractionLikeCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            await _gamificationApp.RemoveFood(request.IdUser, 1, cancellationToken);

            return await _app.Like(request.IdUser, request.IdUserInteraction, cancellationToken);
        }
    }

    #endregion LIKE

    #region GENERATE_CHAT

    public class InteractionGenerateChatCommand : IRequest<bool>
    {
        public string IdUser { get; set; }
        public string IdUserInteraction { get; set; }
    }

    public class InteractionGenerateChatHandler : IRequestHandler<InteractionGenerateChatCommand, bool>
    {
        private readonly IInteractionApp _app;

        public InteractionGenerateChatHandler(IInteractionApp app)
        {
            _app = app;
        }

        public async Task<bool> Handle(InteractionGenerateChatCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return await _app.GenerateChat(request.IdUser, request.IdUserInteraction, cancellationToken);
        }
    }

    #endregion GENERATE_CHAT
}