using System.Threading.Tasks;
using VerusDate.Shared.ViewModel.Query;

namespace VerusDate.Shared.Interface.App
{
    public interface IGlobalInteractionsApp
    {
        Task<GlobalInteractionsVM> Get(string Id);
    }
}