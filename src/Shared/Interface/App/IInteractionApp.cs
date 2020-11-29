using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.ViewModel.Command;
using VerusDate.Shared.ViewModel.Query;

namespace VerusDate.Shared.Interface.App
{
    public interface IInteractionApp
    {
        Task<InteractionVM> Get(string Id, string IdUserInteraction, CancellationToken cancellationToken);

        Task<IEnumerable<InteractionVM>> GetList(string Id, CancellationToken cancellationToken);

        Task<IEnumerable<ProfileBasicVM>> GetLikes(string Id, CancellationToken cancellationToken);

        Task<IEnumerable<ProfileBasicVM>> GetBlinks(string Id, CancellationToken cancellationToken);

        Task<IEnumerable<ProfileBasicVM>> GetNewMatches(string Id, CancellationToken cancellationToken);

        Task<IEnumerable<ProfileChatListVM>> GetChatList(string Id, CancellationToken cancellationToken);

        Task<bool> Blink(string Id, string IdUserInteraction, CancellationToken cancellationToken);

        Task<bool> Block(string Id, string IdUserInteraction, CancellationToken cancellationToken);

        Task<bool> Deslike(string Id, string IdUserInteraction, CancellationToken cancellationToken);

        Task<bool> Like(string Id, string IdUserInteraction, CancellationToken cancellationToken);

        Task<bool> GenerateChat(string Id, string IdUserInteraction, CancellationToken cancellationToken);
    }
}