using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerusDate.Server.Data.EntityConfigHelper;
using VerusDate.Shared.Entity;

namespace VerusDate.Server.Data.EntityConfig
{
    public class ProfileConfig : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.NickName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(p => p.BirthDate)
               .IsRequired();

            builder.Property(p => p.DtInsert)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()");

            builder.Property(p => p.DtTopList)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()");

            builder.Property(p => p.DtLastLogin)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()");

            builder.Property(p => p.BiologicalSex)
                .IsRequired();

            builder.Property(p => p.MaritalStatus)
                .IsRequired();

            builder.Property(p => p.Intent)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(256)
                .HasConversion(ArrayConverter.Intent())
                .Metadata.SetValueComparer(ArrayComparer.Intent());

            builder.Property(p => p.GenderIdentity)
                .IsRequired();

            builder.Property(p => p.SexualOrientation)
                .IsRequired();

            builder.Property(p => p.Latitude)
                .IsRequired();

            builder.Property(p => p.Longitude)
                .IsRequired();

            builder.Property(p => p.Smoke)
                .IsRequired();

            builder.Property(p => p.Drink)
                .IsRequired();

            builder.Property(p => p.Height)
                .IsRequired();

            builder.Property(p => p.BodyMass)
                .IsRequired();

            builder.Property(p => p.RaceCategory)
                .IsRequired();

            builder.Property(p => p.Hobbies)
                .IsUnicode(false)
                .HasMaxLength(1024)
                .HasConversion(ArrayConverter.String())
                .Metadata.SetValueComparer(ArrayComparer.String());

            builder.Property(p => p.MainPhoto)
                .HasMaxLength(512);

            builder.Property(p => p.MainPhotoValidation)
               .HasMaxLength(512);

            builder.Property(p => p.PhotoGallery)
                .IsUnicode(false)
                .HasMaxLength(4000)
                .HasConversion(ArrayConverter.String())
                .Metadata.SetValueComparer(ArrayComparer.String());
        }
    }
}