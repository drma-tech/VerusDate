using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace RealDate.Data.App
{
    public class ProfilePhotosApp : IProfilePhotosApp
    {
        private readonly IRepositoryRead repRead;
        private readonly IRepositoryWrite repWrite;

        public ProfilePhotosApp(IRepositoryRead repRead, IRepositoryWrite repWrite)
        {
            this.repRead = repRead;
            this.repWrite = repWrite;
        }

        public async Task<ProfilePhotosVM> Get(string ProfileId, CancellationToken cancellationToken)
        {
            var obj = await repRead.Get<ProfilePhotosVM>(ProfileId, cancellationToken);

            if (obj == null)
            {
                obj = new ProfilePhotosVM(ProfileId);
                await repWrite.Insert(obj);
            }

            return obj;
        }

        public async Task<bool> PhotoFace(string ProfileId, string fileName, CancellationToken cancellationToken)
        {
            var obj = await Get(ProfileId, cancellationToken);

            obj.UpdatePhotoFace(fileName);

            return await repWrite.Update(obj);
        }
    }
}