using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerusDate.Shared.Entity;

namespace VerusDate.Server.Data.EntityConfig
{
    public class ChatConfig : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(c => new { c.IdChat, c.DtMessage });

            builder.Property(c => c.Content)
                .HasMaxLength(4000);
        }
    }
}