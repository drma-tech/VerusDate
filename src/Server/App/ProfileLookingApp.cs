using System;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace RealDate.Data.App
{
    public class ProfileLookingApp : IProfileLookingApp
    {
        private readonly IRepositoryRead repRead;
        private readonly IRepositoryWrite repWrite;

        public ProfileLookingApp(IRepositoryRead repRead, IRepositoryWrite repWrite)
        {
            this.repRead = repRead;
            this.repWrite = repWrite;
        }

        public async Task<ProfileLookingVM> Get(string ProfileId, CancellationToken cancellationToken)
        {
            return await repRead.Get<ProfileLookingVM>(ProfileId);
        }

        public async Task<bool> Add(ProfileLookingVM obj, CancellationToken cancellationToken)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return await repWrite.Insert(obj);
        }

        public async Task<bool> Update(ProfileLookingVM obj, CancellationToken cancellationToken)
        {
            return await repWrite.Update(obj);
        }
    }
}