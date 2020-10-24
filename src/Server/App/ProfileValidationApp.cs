using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace RealDate.Data.App
{
    public class ProfileValidationApp : IProfileValidationApp
    {
        private readonly IRepositoryRead repRead;
        private readonly IRepositoryWrite repWrite;

        public ProfileValidationApp(IRepositoryRead repRead, IRepositoryWrite repWrite)
        {
            this.repRead = repRead;
            this.repWrite = repWrite;
        }

        public async Task<ProfileValidationVM> Get(string profileId, CancellationToken cancellationToken)
        {
            var obj = await repRead.Get<ProfileValidationVM>(profileId);

            if (obj == null)
            {
                obj = new ProfileValidationVM(profileId);
                await repWrite.Insert(obj);
            }

            return obj;
        }

        public async Task ValidatePhotoFace(string profileId, bool valid, CancellationToken cancellationToken)
        {
            await repWrite.Update("UPDATE ProfileValidation SET PhotoFace = @valid WHERE Id = @profileId", new { profileId, valid });
        }

        public async Task ValidateProfileData(string profileId, bool valid, CancellationToken cancellationToken)
        {
            await repWrite.Update("UPDATE ProfileValidation SET ProfileData = @valid WHERE Id = @profileId", new { profileId, valid });
        }

        public async Task ValidateProfileCriteria(string profileId, bool valid, CancellationToken cancellationToken)
        {
            await repWrite.Update("UPDATE ProfileValidation SET ProfileCriteria = @valid WHERE Id = @profileId", new { profileId, valid });
        }

        public async Task ValidateEmail(string profileId, bool valid, CancellationToken cancellationToken)
        {
            await repWrite.Update("UPDATE ProfileValidation SET Email = @valid WHERE Id = @profileId", new { profileId, valid });
        }

        public async Task ValidatePhone(string profileId, bool valid, CancellationToken cancellationToken)
        {
            await repWrite.Update("UPDATE ProfileValidation SET Phone = @valid WHERE Id = @profileId", new { profileId, valid });
        }

        public async Task ValidateFacebook(string profileId, bool valid, CancellationToken cancellationToken)
        {
            await repWrite.Update("UPDATE ProfileValidation SET Facebook = @valid WHERE Id = @profileId", new { profileId, valid });
        }

        public async Task ValidateInstagram(string profileId, bool valid, CancellationToken cancellationToken)
        {
            await repWrite.Update("UPDATE ProfileValidation SET Instagram = @valid WHERE Id = @profileId", new { profileId, valid });
        }
    }
}