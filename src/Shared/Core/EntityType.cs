using System;

namespace VerusDate.Shared.Core
{
    public abstract class EntityType
    {
        public DateTimeOffset DtInsert { get; private set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? DtUpdate { get; private set; }
    }
}