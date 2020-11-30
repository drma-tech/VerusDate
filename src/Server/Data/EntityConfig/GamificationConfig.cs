using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerusDate.Shared.Entity;

namespace VerusDate.Server.Data.EntityConfig
{
    public class GamificationConfig : IEntityTypeConfiguration<Gamification>
    {
        public void Configure(EntityTypeBuilder<Gamification> builder)
        {
            builder.HasKey(c => c.IdUser);
        }
    }
}