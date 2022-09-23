using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Core;

namespace VerusDate.Api.Core.Interfaces
{
    public interface IRepository
    {
        Task<T> Get<T>(string id, string partitionKeyValue, CancellationToken cancellationToken) where T : CosmosBase;

        Task<List<T>> Query<T>(Expression<Func<T, bool>> predicate, string partitionKeyValue, CosmosType Type, CancellationToken cancellationToken) where T : CosmosBase;

        Task<List<T>> Query<T>(QueryDefinition query, CancellationToken cancellationToken) where T : CosmosBaseQuery;

        Task<T> Add<T>(T item, CancellationToken cancellationToken) where T : CosmosBase;

        Task<bool> Update<T>(T item, CancellationToken cancellationToken) where T : CosmosBase;

        Task<bool> PatchItem<T>(string id, string partitionKeyValue, List<PatchOperation> operations, CancellationToken cancellationToken) where T : CosmosBase;

        Task<bool> Delete<T>(T item, CancellationToken cancellationToken) where T : CosmosBase;
    }
}