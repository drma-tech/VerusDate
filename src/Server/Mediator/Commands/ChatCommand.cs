using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Commands
{
    #region INSERT

    public class ChatInsertCommand : IRequest<bool>
    {
        public List<ChatVM> LstChat { get; private set; }
    }

    public class ChatInsertChatHandler : IRequestHandler<ChatInsertCommand, bool>
    {
        private readonly IChatApp _app;

        public ChatInsertChatHandler(IChatApp app)
        {
            _app = app;
        }

        public async Task<bool> Handle(ChatInsertCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return await _app.Insert(request.LstChat, cancellationToken);
        }
    }

    #endregion INSERT
}