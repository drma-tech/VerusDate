using System;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Model
{
    public class InteractionModel : CosmosBase
    {
        public InteractionModel() : base(CosmosType.Interaction)
        {
        }

        public static string GetId(string IdLoggedUser, string IdUserInteraction)
        {
            return $"{IdLoggedUser}-{IdUserInteraction}";
        }

        public string GetInvertedId()
        {
            return $"{IdUserInteraction}-{IdLoggedUser}";
        }

        public string IdLoggedUser { get; set; }
        public string IdUserInteraction { get; set; }

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

        public override void SetIds(string IdLoggedUser)
        {
            this.IdLoggedUser = IdLoggedUser;
        }

        public void SetIdInteraction(string IdUserInteraction)
        {
            this.SetId($"{IdLoggedUser}-{IdUserInteraction}");
            this.SetPartitionKey(IdLoggedUser);
            this.IdUserInteraction = IdUserInteraction;
        }
    }

    public class Action
    {
        public bool? Value { get; set; }
        public DateTimeOffset? Date { get; set; }

        public void Execute()
        {
            Value = true;
            Date = DateTimeOffset.UtcNow;
        }
    }
}