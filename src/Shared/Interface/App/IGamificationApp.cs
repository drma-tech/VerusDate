using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Enum;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Shared.Interface.App
{
    public interface IGamificationApp
    {
        Task<GamificationVM> Get(string profileId, CancellationToken cancellationToken);

        Task<bool> AddXP(string profileId, EventAddXP eventoXP, CancellationToken cancellationToken);

        Task<bool> RemoveXP(string profileId, EventRemoveXP eventoXP, CancellationToken cancellationToken);

        Task<bool> AddDiamond(string profileId, int qtd, CancellationToken cancellationToken);

        Task<bool> RemoveDiamond(string profileId, int qtd, GamificationVM obj, CancellationToken cancellationToken);

        Task<bool> ExchangeFood(string profileId, int qtdDiamond, CancellationToken cancellationToken);

        Task<bool> RemoveFood(string profileId, int qtd, CancellationToken cancellationToken);
    }
}