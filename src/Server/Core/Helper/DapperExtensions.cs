using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VerusDate.Server.Core.Helper
{
    public class DapperExtensions
    {
        /// <summary>
        /// Monta uma query com 1000 comandos de insert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lst"></param>
        /// <returns></returns>
        public List<string> GetDynamicQuery<T>(IEnumerable<T> lst) where T : class
        {
            if (lst == null || !lst.Any()) return default;

            var type = typeof(T);
            var lstColumns = type.GetColumns();

            var table = TableName(type);
            var columns = string.Join(",", lstColumns.Select(s => $"[{s.Name}]"));
            var counter = 0;
            var values = string.Join(",", lstColumns.Select(s => "{" + counter++ + "}"));

            var insertSql = $"INSERT INTO {table} ({columns}) VALUES ";
            var valuesSql = $"({values})";
            var batchSize = 1000;

            var sqlsToExecute = new List<string>();
            var numberOfBatches = (int)Math.Ceiling((double)lst.Count() / batchSize);

            for (int i = 0; i < numberOfBatches; i++)
            {
                var lst1000 = lst.Skip(i * batchSize).Take(batchSize);

                var valuesToInsert = lst1000.Select(s => string.Format(valuesSql, s.GetType().GetValues(s).ToArray()));
                sqlsToExecute.Add(insertSql + string.Join(",", valuesToInsert));
            }

            return sqlsToExecute;
        }

        /// <summary>
        /// Pega o atributo 'Dapper.Contrib.Extensions.Table' da classe
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string TableName(Type type)
        {
            // Check if we've already set our custom table mapper to TableNameMapper.
            if (SqlMapperExtensions.TableNameMapper != null)
                return SqlMapperExtensions.TableNameMapper(type);

            // If not, we can use Dapper default method "SqlMapperExtensions.GetTableName(Type type)" which is unfortunately private, that's why we have to call it via reflection.
            string getTableName = "GetTableName";
            MethodInfo getTableNameMethod = typeof(SqlMapperExtensions).GetMethod(getTableName, BindingFlags.NonPublic | BindingFlags.Static);

            if (getTableNameMethod == null)
                throw new ArgumentOutOfRangeException($"Method '{getTableName}' is not found in '{nameof(SqlMapperExtensions)}' class.");

            return getTableNameMethod.Invoke(null, new object[] { type }) as string;
        }
    }

    public static class TypeExtensions
    {
        /// <summary>
        /// Recupera todas as propriedades públicas - ignora os que tem o atributo 'Computed'
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetColumns(this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return type
                .GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance)
                .Where(pi => !pi.IsDefined(typeof(ComputedAttribute)))
                .AsEnumerable();
        }

        public static IEnumerable<string> GetValues(this Type type, object obj)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetValuesIterator(type, obj);
        }

        private static IEnumerable<string> GetValuesIterator(Type type, object obj)
        {
            foreach (var item in type.GetColumns())
            {
                var value = item.GetValue(obj);

                if (value == null)
                    yield return "null";
                else if (value is DateTime)
                    yield return $"'{(DateTime)item.GetValue(obj):yyyy-MM-ddTHH:mm:ss}'";
                else if (value is DateTimeOffset)
                    yield return $"'{(DateTimeOffset)item.GetValue(obj):yyyy-MM-ddTHH:mm:ss}'";
                else
                    yield return $"'{item.GetValue(obj)}'";
            }
        }
    }
}