using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VerusDate.Api.Core
{
    public static class QueryExtensions
    {
        public static void AddEnumFilter<T>(this StringBuilder sb, IReadOnlyList<T> list, string field)
        {
            if (list.Any())
            {
                sb.Append($" AND {field} IN (" + string.Join(",", list.Cast<int>()) + ") ");
            }
        }

        public static void AddArrayFilter<T>(this StringBuilder sb, IReadOnlyList<T> list, string field)
        {
            if (list.Any())
            {
                sb.Append($" AND EXISTS(SELECT VALUE n FROM n IN {field} WHERE n in (" + string.Join(",", list.Cast<int>()) + ")) ");
            }
        }
    }
}