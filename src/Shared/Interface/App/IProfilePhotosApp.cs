using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Shared.Interface.App
{
    public interface IProfilePhotosApp
    {
        Task<ProfilePhotosVM> Get(string ProfileId, CancellationToken cancellationToken);

        Task<bool> PhotoFace(string ProfileId, string fileName, CancellationToken cancellationToken);
    }
}