using Microsoft.Azure.CosmosRepository.Attributes;
using System;
using System.Text.Json.Serialization;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Model
{
    [PartitionKeyPath("idPrimary")]
    public class Interaction : ModelBase
    {
        /// <summary>
        /// Id do usuário logado
        /// </summary>
        [JsonPropertyName("idPrimary")]
        public string IdPrimary { get; set; }

        /// <summary>
        /// Id do usuário que recebeu a interação
        /// </summary>
        [JsonPropertyName("idSecondary")]
        public string IdSecondary { get; set; }

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

        /// <summary>
        /// Gera uma interação entre dois usuários
        /// </summary>
        /// <param name="IdPrimary">Id do usuário logado</param>
        /// <param name="IdSecondary">Id do usuário que recebeu a interação</param>
        public Interaction(string IdPrimary, string IdSecondary)
        {
            this.Id = $"{IdPrimary}-{IdSecondary}";
            this.IdPrimary = IdPrimary;
            this.IdSecondary = IdSecondary;
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