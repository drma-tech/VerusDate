using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;
using VerusDate.Shared.Enum;

namespace VerusDate.Server.Data.EntityConfigHelper
{
    public static class ArrayConverter
    {
        public static ValueConverter String()
        {
            return new ValueConverter<string[], string>(
                v => string.Join(";", v),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => val).ToArray());
        }

        public static ValueConverter Intent()
        {
            return new ValueConverter<Intent[], string>(
                v => string.Join(";", v),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => (Intent)int.Parse(val)).ToArray());
        }
    }
}