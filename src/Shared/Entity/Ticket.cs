using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Entity
{
    public class Ticket : EntityType
    {
        [Key]
        public string Id { get; set; }

        public string IdUserOwner { get; set; }
        public DateTimeOffset DtTicket { get; set; }
        public TicketType TicketType { get; set; }
        public string Description { get; set; }
        public int TotalVotes { get; set; }
        public TicketStatus TicketStatus { get; set; }
    }
}