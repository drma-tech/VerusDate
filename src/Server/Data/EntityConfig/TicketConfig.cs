using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerusDate.Shared.Entity;

namespace VerusDate.Server.Data.EntityConfig
{
    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(c => c.IdTicket);

            builder.Property(c => c.IdTicket)
                .HasDefaultValueSql("NEWID()");

            builder.Property(c => c.IdUser)
                .IsRequired();

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(512);
        }
    }
}