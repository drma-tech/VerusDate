using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Shared.Interface.App
{
    public interface IProfileLookingApp
    {
        Task<ProfileLookingVM> Get(string ProfileId, CancellationToken cancellationToken);

        Task<bool> Add(ProfileLookingVM obj, CancellationToken cancellationToken);

        Task<bool> Update(ProfileLookingVM obj, CancellationToken cancellationToken);
    }
}