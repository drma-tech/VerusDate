using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerusDate.Server.Data.EntityConfigHelper;
using VerusDate.Shared.Entity;

namespace VerusDate.Server.Data.EntityConfig
{
    public class ProfileLookingConfig : IEntityTypeConfiguration<ProfileLooking>
    {
        public void Configure(EntityTypeBuilder<ProfileLooking> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Intent)
               .IsRequired()
               .IsUnicode(false)
               .HasMaxLength(256)
               .HasConversion(ArrayConverter.Intent())
               .Metadata.SetValueComparer(ArrayComparer.Intent());

            builder.Property(p => p.Distance)
               .IsRequired();

            builder.Property(p => p.MinimalAge)
               .IsRequired();

            builder.Property(p => p.MaxAge)
               .IsRequired();
        }
    }
}