using System.Threading.Tasks;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Shared.Interface.App
{
    public interface IGlobalInteractionsApp
    {
        Task<GlobalInteractionsVM> Get(string Id);
    }
}