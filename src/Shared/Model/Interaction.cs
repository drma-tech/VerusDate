using Microsoft.Azure.CosmosRepository.Attributes;
using System;
using System.Text.Json.Serialization;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Model
{
    [PartitionKeyPath("idInteraction")]
    public class Interaction : ModelBase
    {
        [JsonPropertyName("idInteraction")]
        public string IdInteraction { get; set; }

        public ValueType.Action Like { get; set; }
        public ValueType.Action Deslike { get; set; }
        public ValueType.Action Blink { get; set; }
        public ValueType.Action Match { get; set; }
        public ValueType.Action Block { get; set; }

        public string IdChat { get; set; }

        public override void LoadDefatultData()
        {
            throw new NotImplementedException();
        }

        public void ExecuteLike()
        {
            Like.Execute();
            base.Update();
        }

        public void ExecuteDeslike()
        {
            Deslike.Execute();
            base.Update();
        }

        public void ExecuteBlink()
        {
            Blink.Execute();
            base.Update();
        }

        public void ExecuteMatch()
        {
            if (!Like.Value) throw new InvalidOperationException("Ação só poderá ser feita depois do like");

            Match.Execute();
            base.Update();
        }

        public void ExecuteBlock()
        {
            if (!Match.Value) throw new InvalidOperationException("Ação só poderá ser feita depois do match");

            Block.Execute();
            base.Update();
        }
    }
}