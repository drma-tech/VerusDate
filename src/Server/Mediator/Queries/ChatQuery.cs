using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries
{
    #region GET

    public class ChatGetCommand : IRequest<IEnumerable<ChatVM>>
    {
        public string IdChat { get; set; }
        public string IdUser { get; set; }
    }

    public class ChatGetHandler : IRequestHandler<ChatGetCommand, IEnumerable<ChatVM>>
    {
        private readonly IChatApp _app;

        public ChatGetHandler(IChatApp app)
        {
            _app = app;
        }

        public async Task<IEnumerable<ChatVM>> Handle(ChatGetCommand request, CancellationToken cancellationToken)
        {
            return await _app.Get(request.IdChat, request.IdUser, cancellationToken);
        }
    }

    #endregion GET
}