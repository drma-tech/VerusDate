using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Shared.Interface.App
{
    public interface IProfileApp
    {
        Task<bool> Add(ProfileLookingVM obj);

      
      

        Task<int> RegisterLogin(string ProfileId, CancellationToken cancellationToken);

        Task<bool> Update(ProfileLookingVM obj);

        Task<bool> Update(ProfileVM obj);
    }
}