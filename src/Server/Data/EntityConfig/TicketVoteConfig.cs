using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerusDate.Shared.Entity;

namespace VerusDate.Server.Data.EntityConfig
{
    public class TicketVoteConfig : IEntityTypeConfiguration<TicketVote>
    {
        public void Configure(EntityTypeBuilder<TicketVote> builder)
        {
            builder.HasKey(c => new { c.IdTicket, c.IdUser });
        }
    }
}