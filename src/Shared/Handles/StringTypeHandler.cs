using Dapper;
using System;
using System.Data;
using System.Linq;

namespace VerusDate.Shared.Handles
{
    public class StringTypeHandler : SqlMapper.TypeHandler<string[]>
    {
        public override string[] Parse(object value)
        {
            return value.ToString().Split(';', StringSplitOptions.RemoveEmptyEntries).Select(val => val).ToArray();
        }

        public override void SetValue(IDbDataParameter parameter, string[] value)
        {
            parameter.Value = string.Join(";", value);
        }
    }
}