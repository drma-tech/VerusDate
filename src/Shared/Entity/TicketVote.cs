using System;
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

        public DateTimeOffset DtVote { get; set; }
    }
}