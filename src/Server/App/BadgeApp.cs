using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace RealDate.Data.App
{
    public class BadgeApp : IBadgeApp
    {
        private readonly IRepository _repos;

        public BadgeApp(IRepository repos)
        {
            _repos = repos;
        }

        public async Task<BadgeVM> Get(string profileId)
        {
            var obj = await _repos.Get<BadgeVM>(profileId);

            if (obj == null)
            {
                obj = new BadgeVM(profileId);
                await _repos.Insert(obj);
            }

            return obj;
        }
    }
}