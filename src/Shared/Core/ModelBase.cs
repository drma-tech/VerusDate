using Microsoft.Azure.CosmosRepository;
using System;
using VerusDate.Shared.Helper;

namespace VerusDate.Shared.Core
{
    /// <summary>
    /// Estrutura que espelha a classe original (Entity) -> Ideal para comandos de INSERT e UPDATE
    /// <para>OBS: Para comandos de UPDATE, não esquecer de chamar o método Update()</para>
    /// </summary>
    public abstract class ModelBase : Item
    {
        public DateTimeOffset DtInsert { get; private set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? DtUpdate { get; private set; }

        /// <summary>
        /// Aqui devem ser inicializados atributos que contenham valores default (evite utilizar o construtor para este propósito)
        /// <para>OBS: atributos de coleções devem ser inicializados no próprio atributo, no caso de esse método não ser chamado</para>
        /// </summary>
        public abstract void LoadDefatultData();

        /// <summary>
        /// Atributos manipulados por este método, por métodos PATCH ou que contenham regras de negócio devem ser protegidos com "private set;"
        /// </summary>
        public virtual void Update()
        {
            DtUpdate = DateTimeOffset.UtcNow;
        }

        public int DaysInsert()
        {
            return ProfileHelper.GetDaysPassed(DtInsert);
        }

        public int DaysUpdate()
        {
            if (!DtUpdate.HasValue) return DaysInsert();

            return ProfileHelper.GetDaysPassed(DtUpdate.Value);
        }
    }
}