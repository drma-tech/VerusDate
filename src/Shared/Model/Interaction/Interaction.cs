using System;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Model.Interaction
{
    public class Interaction : CosmosBase
    {
        public Interaction() : base("Interaction")
        {
        }

        public void SetId(string IdLoggedUser, string IdUserInteraction)
        {
            this.Id = $"{IdLoggedUser}-{IdUserInteraction}";
            this.Key = IdLoggedUser;

            this.IdLoggedUser = IdLoggedUser;
            this.IdUserInteraction = IdUserInteraction;
        }

        public string GetInvertedId()
        {
            return $"{IdUserInteraction}-{IdLoggedUser}";
        }

        public string IdLoggedUser { get; set; }
        public string IdUserInteraction { get; set; }

        public DateTimeOffset? DtInsert { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? DtUpdate { get; set; }
        public Action Like { get; set; } = new Action();
        public Action Deslike { get; set; } = new Action();
        public Action Blink { get; set; } = new Action();
        public Action Match { get; set; } = new Action();
        public Action Block { get; set; } = new Action();

        public string IdChat { get; set; }

        public void ExecuteLike()
        {
            Like.Execute();
            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void ExecuteDeslike()
        {
            Deslike.Execute();
            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void ExecuteBlink()
        {
            Blink.Execute();
            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void ExecuteMatch()
        {
            if (!Like.Value.Value) throw new InvalidOperationException("Ação só poderá ser feita depois do like");

            Match.Execute();
            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void ExecuteBlock()
        {
            if (!Match.Value.Value) throw new InvalidOperationException("Ação só poderá ser feita depois do match");

            Block.Execute();
            DtUpdate = DateTimeOffset.UtcNow;
        }
    }
}