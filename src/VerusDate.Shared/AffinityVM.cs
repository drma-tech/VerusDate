using System.Collections.Generic;

namespace VerusDate.Shared
{
    public enum AffinityCategory
    {
        Basic,
        Bio,
        Lifestyle,
        Personality,
        Interest
    }

    public class AffinityVM
    {
        public AffinityVM(AffinityCategory Category, string AttributeName, bool HaveAffinity, IEnumerable<int> ArrayEnums = default)
        {
            this.Category = Category;
            this.AttributeName = AttributeName;
            this.HaveAffinity = HaveAffinity;
            this.ArrayEnums = ArrayEnums;
        }

        public AffinityCategory Category { get; set; }
        public string AttributeName { get; set; }
        public bool HaveAffinity { get; set; }
        public IEnumerable<int> ArrayEnums { get; set; }
    }
}