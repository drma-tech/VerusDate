using System;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Core
{
    public abstract class CosmosBase
    {
        protected CosmosBase(string Type)
        {
            if (string.IsNullOrEmpty(Type)) throw new ArgumentNullException(nameof(Type));

            this.Type = Type;
        }

        /// <summary>
        /// Data de inserção do registro
        /// </summary>
        public DateTimeOffset? DtInsert { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// Data de atualização de um ou mais campos (após o insert)
        /// </summary>
        public DateTimeOffset? DtUpdate { get; set; }

        /// <summary>
        /// Campo único dentro do container
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// PartitionKeyPath (Partição Lógica)
        /// <para>Se for uma estrutura 'pai', usar o valor do Id</para>
        /// <para>Se for uma estrutura 'filha', usar o valor do Id da estrutura 'pai'</para>
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Tipo da estrutura (geralmente o nome da classe)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Recupera o status dos dados atuais
        /// </summary>
        /// <returns></returns>
        public DataStatus GetDataStatus()
        {
            if (string.IsNullOrEmpty(Id)) return DataStatus.New;
            else if (!DtUpdate.HasValue) return DataStatus.Inserted;
            else return DataStatus.Inserted_Updated;
        }

        /// <summary>
        /// Configura atributos dos campos chaves
        /// </summary>
        /// <param name="IdUser">Id do usuário capturado do token</param>
        public abstract void SetIds(string IdLoggedUser);
    }
}