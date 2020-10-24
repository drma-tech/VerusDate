using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.ViewModel
{
    [Table("Interaction")]
    public class InteractionVM : ViewModelType
    {
        /// <summary>
        /// Use for API
        /// </summary>
        public InteractionVM()
        {
        }

        /// <summary>
        /// Use for insert
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="IdUserInteraction"></param>
        public InteractionVM(string Id, string IdUserInteraction)
        {
            this.Id = Id;
            this.IdUserInteraction = IdUserInteraction;
        }

        [ExplicitKey]
        public string Id { get; set; }

        [ExplicitKey]
        public string IdUserInteraction { get; set; }

        [Required]
        public DateTimeOffset DtInsert { get; set; } = DateTimeOffset.UtcNow;

        public ValueType.Action Like { get; set; }
        public ValueType.Action Deslike { get; set; }
        public ValueType.Action Match { get; set; }
        public ValueType.Action Blink { get; set; }
        public ValueType.Action Block { get; set; }

        public string IdChat { get; set; }

        public void ExecuteLike()
        {
            Like.Execute();
        }

        public void ExecuteDeslike()
        {
            if (!Like.Value) throw new InvalidOperationException("Ação só poderá ser feita depois do like");

            Deslike.Execute();
        }

        public void ExecuteMatch()
        {
            if (!Like.Value) throw new InvalidOperationException("Ação só poderá ser feita depois do like");

            Match.Execute();
        }

        public void ExecuteBlink()
        {
            Blink.Execute();
        }

        public void ExecuteBlock()
        {
            if (!Match.Value) throw new InvalidOperationException("Ação só poderá ser feita depois do match");

            Block.Execute();
        }
    }
}