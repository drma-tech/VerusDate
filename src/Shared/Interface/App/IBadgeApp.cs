using System.Threading.Tasks;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Shared.Interface.App
{
    public interface IBadgeApp
    {
        Task<BadgeVM> Get(string profileId);
    }
}