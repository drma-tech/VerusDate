using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerusDate.Server.Data.EntityConfigHelper;
using VerusDate.Shared.Entity;

namespace VerusDate.Server.Data.EntityConfig
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(c => c.IdEvent);

            builder.Property(c => c.IdEvent)
               .HasDefaultValueSql("NEWID()");

            builder.Property(c => c.Location)
               .IsRequired();

            builder.Property(p => p.Intent)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(256)
                .HasConversion(ArrayConverter.Intent())
                .Metadata.SetValueComparer(ArrayComparer.Intent());

            builder.Property(p => p.SexualOrientation)
               .IsRequired()
               .IsUnicode(false)
               .HasMaxLength(256)
               .HasConversion(ArrayConverter.SexualOrientation())
               .Metadata.SetValueComparer(ArrayComparer.SexualOrientation());
        }
    }
}