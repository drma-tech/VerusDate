using System;

namespace VerusDate.Shared.Core
{
    public class CosmosBase
    {
        /// <summary>
        /// Campo único dentro do container
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Tipo da estrutura (geralmente o nome da classe)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// PartitionKeyPath (Partição Lógica)
        /// <para>Se for uma estrutura 'pai', usar o valor do Id</para>
        /// <para>Se for uma estrutura 'filha', usar o valor do Id da estrutura 'pai'</para>
        /// </summary>
        public string Key { get; set; }

        public CosmosBase(string Type)
        {
            if (string.IsNullOrEmpty(Type)) throw new ArgumentNullException(nameof(Type));

            this.Type = Type;
        }
    }
}