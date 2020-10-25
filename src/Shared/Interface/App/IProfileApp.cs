using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Shared.Interface.App
{
    public interface IProfileApp
    {
        Task<bool> Add(ProfileLookingVM obj);

        Task<bool> Add(ProfileUserVM obj);

        Task<ProfileLookingVM> Get(string ProfileId);

        Task<IEnumerable<ProfileViewVM>> GetListMatch(ProfileLookingVM looking, CancellationToken cancellationToken);

        Task<IEnumerable<ProfileViewVM>> GetListSearch(ProfileLookingVM looking, CancellationToken cancellationToken);

        Task<ProfileUserVM> GetUser(string ProfileId);

        Task<ProfileViewVM> GetView(string IdUser, string IdUserView);

        Task RegisterLogin(string ProfileId, CancellationToken cancellationToken);

        Task<bool> Update(ProfileLookingVM obj);

        Task<bool> Update(ProfileUserVM obj);
    }
}