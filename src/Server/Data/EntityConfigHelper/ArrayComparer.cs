using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using VerusDate.Shared.Enum;

namespace VerusDate.Server.Data.EntityConfigHelper
{
    public static class ArrayComparer
    {
        public static ValueComparer String()
        {
            return new ValueComparer<string[]>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToArray());
        }

        public static ValueComparer Intent()
        {
            return new ValueComparer<Intent[]>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToArray());
        }

        public static ValueComparer SexualOrientation()
        {
            return new ValueComparer<SexualOrientation[]>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToArray());
        }
    }
}