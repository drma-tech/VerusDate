using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Enum;

namespace VerusDate.Server.App
{
    public class GamificationApp : IGamificationApp
    {
        private readonly IRepository _repo;

        public GamificationApp(IRepository repo)
        {
            _repo = repo;
        }

    
        private async Task<bool> Update(GamificationVM gamification)
        {
            return await _repo.Update(gamification);
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
            return true;
        }

        public async Task<bool> RemoveFood(string profileId, int qtd, CancellationToken cancellationToken)
        {
            var obj = await Get(profileId, cancellationToken);

            obj.RemoveFood(qtd);

            return await Update(obj);
        }
    }
}