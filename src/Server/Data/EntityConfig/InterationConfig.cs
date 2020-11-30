using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerusDate.Shared.Entity;
using VerusDate.Shared.ValueType;

namespace VerusDate.Server.Data.EntityConfig
{
    public class InteractionConfig : IEntityTypeConfiguration<Interaction>
    {
        public void Configure(EntityTypeBuilder<Interaction> builder)
        {
            builder.HasKey(c => new { c.IdUser, c.IdUserInteraction });

            builder.OwnsOne(typeof(Action), "Like");

            builder.OwnsOne(typeof(Action), "Deslike");

            builder.OwnsOne(typeof(Action), "Match");

            builder.OwnsOne(typeof(Action), "Blink");

            builder.OwnsOne(typeof(Action), "Block");
        }
    }
}