using VerusDate.Shared.Core;

namespace VerusDate.Shared.ViewModel
{
    public class AffinityVM : ViewModelType
    {
        public AffinityVM(string AttributeName, bool HaveAffinity)
        {
            this.AttributeName = AttributeName;
            this.HaveAffinity = HaveAffinity;
        }

        public string AttributeName { get; set; }
        public bool HaveAffinity { get; set; }
    }
}