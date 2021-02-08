using System.Collections.Generic;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared
{
    public class AffinityVM
    {
        public AffinityVM(string AttributeName, bool HaveAffinity, IEnumerable<Intent> Intent = null)
        {
            this.AttributeName = AttributeName;
            this.HaveAffinity = HaveAffinity;
            this.Intent = Intent;
        }

        public string AttributeName { get; set; }
        public bool HaveAffinity { get; set; }
        public IEnumerable<Intent> Intent { get; set; }
    }
}