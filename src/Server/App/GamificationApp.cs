using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace RealDate.Data.App
{
    public class GamificationApp : IGamificationApp
    {
        private readonly IRepositoryRead repRead;
        private readonly IRepositoryWrite repWrite;

        public GamificationApp(IRepositoryRead repRead, IRepositoryWrite repWrite)
        {
            this.repRead = repRead;
            this.repWrite = repWrite;
        }

        public async Task<GamificationVM> Get(string profileId, CancellationToken cancellationToken)
        {
            var obj = await repRead.Get<GamificationVM>(profileId);

            if (obj == null)
            {
                obj = new GamificationVM(profileId);
                await repWrite.Insert(obj);
            }

            return obj;
        }

        private async Task<bool> Update(GamificationVM gamification)
        {
            return await repWrite.Update(gamification);
        }

        public async Task<bool> AddXP(string profileId, EventAddXP eventoXP, CancellationToken cancellationToken)
        {
            var obj = await Get(profileId, cancellationToken);

            obj.AddXP(GetXP(eventoXP));

            return await Update(obj);
        }

        private static int GetXP(EventAddXP eventoXP)
        {
            return eventoXP switch
            {
                EventAddXP.ValidatePhotoFace => 30,
                EventAddXP.ValidateProfileData => 30,
                EventAddXP.ValidateProfileCriteria => 30,
                EventAddXP.ValidateEmail => 30,
                EventAddXP.ValidatePhone => 30,
                EventAddXP.ValidateFacebook => 30,
                EventAddXP.ValidateInstagram => 30,
                _ => 0
            };
        }

        private static int GetXP(EventRemoveXP eventoXP)
        {
            return eventoXP switch
            {
                EventRemoveXP.UpdateProfile => 100,
                _ => 0
            };
        }

        public async Task<bool> RemoveXP(string profileId, EventRemoveXP eventoXP, CancellationToken cancellationToken)
        {
            var obj = await Get(profileId, cancellationToken);

            obj.RemoveXP(GetXP(eventoXP));

            return await Update(obj);
        }

        public async Task<bool> AddDiamond(string profileId, int qtd, CancellationToken cancellationToken)
        {
            var obj = await Get(profileId, cancellationToken);

            obj.AddDiamond(qtd);

            return await Update(obj);
        }

        public async Task<bool> RemoveDiamond(string profileId, int qtd, GamificationVM obj, CancellationToken cancellationToken)
        {
            if (obj == null)
            {
                obj = await Get(profileId, cancellationToken);
            }

            obj.RemoveDiamond(qtd);

            return await Update(obj);
        }

        public async Task<bool> ExchangeFood(string profileId, int qtdDiamond, CancellationToken cancellationToken)
        {
            var obj = await Get(profileId, cancellationToken);

            obj.ExchangeFood(qtdDiamond);

            return await Update(obj);
        }

        public async Task<bool> RemoveFood(string profileId, int qtd, CancellationToken cancellationToken)
        {
            var obj = await Get(profileId, cancellationToken);

            obj.RemoveFood(qtd);

            return await Update(obj);
        }
    }
}