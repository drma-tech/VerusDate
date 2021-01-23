using System;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Core
{
    public enum CosmosType
    {
        Principal = 1,
        Profile = 2,
        Interaction = 3,
        Chat = 4,
        Ticket = 5,
        TicketVote = 6,
        Event = 7
    }

    public abstract class CosmosBase
    {
        //TODO: proteger os atributos assim que a leitura dos dados na classe conseguir atribuir valores

        protected CosmosBase(CosmosType Type)
        {
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
        /// Campo único dentro do container (tem distinção por tipo)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// PartitionKeyPath (Partição Lógica)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Tipo da estrutura (geralmente o nome da classe)
        /// </summary>
        public CosmosType Type { get; set; }

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
        /// Configura o id do objeto (vai ser mesclado com o tipo)
        /// </summary>
        /// <param name="id"></param>
        public void SetId(string id)
        {
            Id = Type + ":" + id;
        }

        /// <summary>
        /// PartitionKeyPath (Partição Lógica)
        /// <para>Se for uma estrutura 'pai', usar o valor do Id</para>
        /// <para>Se for uma estrutura 'filha', usar o valor do Id da estrutura 'pai'</para>
        /// </summary>
        public void SetPartitionKey(string id)
        {
            Key = id;
        }

        /// <summary>
        /// Configura atributos dos campos chaves (mesclar com o campo Type)
        /// </summary>
        /// <param name="IdUser">Id do usuário capturado do token</param>
        public abstract void SetIds(string IdLoggedUser);
    }

    public class CosmosBaseQuery
    {
    }
}