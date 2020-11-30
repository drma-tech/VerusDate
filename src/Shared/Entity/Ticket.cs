using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Entity
{
    public class Ticket : EntityType
    {
        [Key]
        public string IdTicket { get; set; }

        public string IdUser { get; set; }
        public TicketType TicketType { get; set; }
        public string Description { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public int TotalVotes { get; set; }

        public IEnumerable<TicketVote> TicketVotes { get; set; }
        public Profile Profile { get; set; }
    }
}