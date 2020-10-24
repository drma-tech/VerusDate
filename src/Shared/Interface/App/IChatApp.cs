using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Shared.Interface.App
{
    public interface IChatApp
    {
        Task<IEnumerable<ChatVM>> Get(string IdChat, string IdUser, CancellationToken cancellationToken);

        Task<bool> Insert(List<ChatVM> lstChat, CancellationToken cancellationToken);
    }
}