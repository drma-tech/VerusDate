using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Shared.Interface.App
{
    public interface IProfileApp
    {
        Task<ProfileUserVM> GetUser(string ProfileId, CancellationToken cancellationToken);

        Task<ProfileViewVM> GetView(string IdUser, string IdUserView, CancellationToken cancellationToken);

        Task<IEnumerable<ProfileViewVM>> GetListMatch(ProfileLookingVM looking, CancellationToken cancellationToken);

        Task<IEnumerable<ProfileViewVM>> GetListSearch(ProfileLookingVM looking, CancellationToken cancellationToken);

        Task<bool> Add(ProfileUserVM obj, CancellationToken cancellationToken);

        Task<bool> Update(ProfileUserVM obj, CancellationToken cancellationToken);

        Task RegisterLogin(string ProfileId, CancellationToken cancellationToken);
    }
}