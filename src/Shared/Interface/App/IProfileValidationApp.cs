using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Shared.Interface.App
{
    public interface IProfileValidationApp
    {
        Task<ProfileValidationVM> Get(string profileId, CancellationToken cancellationToken);

        Task ValidatePhotoFace(string profileId, bool valid, CancellationToken cancellationToken);

        Task ValidateProfileData(string profileId, bool valid, CancellationToken cancellationToken);

        Task ValidateProfileCriteria(string profileId, bool valid, CancellationToken cancellationToken);

        Task ValidateEmail(string profileId, bool valid, CancellationToken cancellationToken);

        Task ValidatePhone(string profileId, bool valid, CancellationToken cancellationToken);

        Task ValidateFacebook(string profileId, bool valid, CancellationToken cancellationToken);

        Task ValidateInstagram(string profileId, bool valid, CancellationToken cancellationToken);
    }
}