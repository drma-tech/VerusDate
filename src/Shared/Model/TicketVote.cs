using Microsoft.Azure.CosmosRepository.Attributes;
using System;
using System.Text.Json.Serialization;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Model
{
    [PartitionKeyPath("idVotedUser")]
    public class TicketVote : ModelBase
    {
        [JsonPropertyName("idVotedUser")]
        public string IdVotedUser { get; set; }

        public override void LoadDefatultData()
        {
            throw new NotImplementedException();
        }
    }
}