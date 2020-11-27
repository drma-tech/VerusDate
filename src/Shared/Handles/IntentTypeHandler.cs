using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Handles
{
    public class IntentTypeHandler : SqlMapper.TypeHandler<IReadOnlyList<Intent>>
    {
        public override IReadOnlyList<Intent> Parse(object value)
        {
            return value.ToString().Split(';', StringSplitOptions.RemoveEmptyEntries).Select(val => (Intent)int.Parse(val)).ToList();
        }

        public override void SetValue(IDbDataParameter parameter, IReadOnlyList<Intent> value)
        {
            parameter.Value = string.Join(";", value.Select(val => (int)val).ToList());
        }
    }
}