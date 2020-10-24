using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerusDate.Shared.Entity;

namespace VerusDate.Server.Data.EntityConfig
{
    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(c => c.DtTicket)
                .HasDefaultValueSql("SYSDATETIMEOFFSET()");
        }
    }
}