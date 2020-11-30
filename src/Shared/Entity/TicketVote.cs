using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Entity
{
    public class TicketVote : EntityType
    {
        [Key]
        public string IdTicket { get; set; }

        [Key]
        public string IdUser { get; set; }

        public Ticket Ticket { get; set; }
        public Profile Profile { get; set; }
    }
}