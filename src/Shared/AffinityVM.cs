namespace VerusDate.Shared
{
    public class AffinityVM
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