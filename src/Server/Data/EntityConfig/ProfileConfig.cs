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
            builder.HasKey(c => c.IdUser);

            builder.Property(p => p.NickName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(c => c.Location)
               .IsRequired();

            builder.Property(p => p.Intent)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(256)
                .HasConversion(ArrayConverter.Intent())
                .Metadata.SetValueComparer(ArrayComparer.Intent());

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

            builder.HasOne(p => p.ProfileLooking).WithOne(p => p.Profile).HasForeignKey<ProfileLooking>(p => p.IdUser);

            builder.HasOne(p => p.Gamification).WithOne(p => p.Profile).HasForeignKey<Gamification>(p => p.IdUser);

            builder.HasOne(p => p.Badge).WithOne(p => p.Profile).HasForeignKey<Badge>(p => p.IdUser);

            builder.HasMany(p => p.Events).WithOne(p => p.Profile).HasForeignKey(p => p.IdUser).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Tickets).WithOne(p => p.Profile).HasForeignKey(p => p.IdUser).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.TicketVotes).WithOne(p => p.Profile).HasForeignKey(p => p.IdUser).OnDelete(DeleteBehavior.NoAction);
        }
    }
}