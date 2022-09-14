using VerusDate.Shared.Enum;

namespace VerusDate.Shared
{
    public class AffinityVM
    {
        public AffinityVM(Section section, CompatibilityItem Item, bool HaveAffinity)
        {
            this.Section = section;
            this.Item = Item;
            this.HaveAffinity = HaveAffinity;
        }

        public Section Section { get; set; }
        public CompatibilityItem Item { get; set; }
        public bool HaveAffinity { get; set; }
    }
}