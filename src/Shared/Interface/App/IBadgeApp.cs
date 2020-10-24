using System.Threading.Tasks;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Shared.Interface.App
{
    public interface IBadgeApp
    {
        Task<BadgeVM> Get(string profileId);
    }
}