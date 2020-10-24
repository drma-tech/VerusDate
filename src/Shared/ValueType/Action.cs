using Microsoft.EntityFrameworkCore;
using System;

namespace VerusDate.Shared.ValueType
{
    [Owned]
    public class Action
    {
        public bool Value { get; set; }
        public DateTimeOffset Date { get; set; }

        public void Execute()
        {
            Value = true;
            Date = DateTimeOffset.UtcNow;
        }
    }
}