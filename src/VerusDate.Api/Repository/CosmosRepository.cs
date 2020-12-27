using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;

namespace VerusDate.Api.Repository
{
    public class CosmosRepository : IRepository
    {
        public Container Container { get; private set; }

        public CosmosRepository(IConfiguration config)
        {
            var connString = config.GetValue<string>("RepositoryOptions:CosmosConnectionString");
            var databaseId = config.GetValue<string>("RepositoryOptions:DatabaseId");
            var containerId = config.GetValue<string>("RepositoryOptions:ContainerId");

            var _client = new CosmosClient(connString, new CosmosClientOptions()
            {
                SerializerOptions = new CosmosSerializationOptions()
                {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                }
            });

            Container = _client.GetContainer(databaseId, containerId);
        }

        public async Task<T> Get<T>(string id, string partitionKeyValue, CancellationToken cancellationToken) where T : CosmosBase
        {
            var response = await Container.ReadItemAsync<T>(id, new PartitionKey(partitionKeyValue), null, cancellationToken);

            return response.Resource;
        }

        public async Task<List<T>> Query<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken) where T : CosmosBase
        {
            return await Query(predicate, null, cancellationToken);
        }

        private QueryRequestOptions GetDefaultOptions(string partitionKeyValue)
        {
            if (string.IsNullOrEmpty(partitionKeyValue))
                return null;
            else
                return new QueryRequestOptions() { PartitionKey = new PartitionKey(partitionKeyValue) };
        }

        public async Task<List<T>> Query<T>(Expression<Func<T, bool>> predicate, string partitionKeyValue, CancellationToken cancellationToken) where T : CosmosBase
        {
            IQueryable<T> query = Container.GetItemLinqQueryable<T>(requestOptions: GetDefaultOptions(partitionKeyValue))
                .Where(predicate.Compose(item => item.Type == typeof(T).Name, Expression.AndAlso));

            using (FeedIterator<T> iterator = query.ToFeedIterator())
            {
                List<T> results = new List<T>();

                while (iterator.HasMoreResults)
                {
                    foreach (var item in await iterator.ReadNextAsync(cancellationToken))
                    {
                        results.Add(item);
                    }
                }

                return results;
            }
        }

        public async Task<T> Add<T>(T item, string partitionKeyValue, CancellationToken cancellationToken) where T : CosmosBase
        {
            item.Key = partitionKeyValue;

            var response = await Container.CreateItemAsync(item, new PartitionKey(partitionKeyValue), null, cancellationToken);

            return response.Resource;
        }

        public async Task<T> Update<T>(T item, string id, string partitionKeyValue, CancellationToken cancellationToken) where T : CosmosBase
        {
            item.Key = partitionKeyValue;

            var response = await Container.ReplaceItemAsync(item, id, new PartitionKey(partitionKeyValue), null, cancellationToken);

            return response.Resource;
        }

        public async Task<T> Delete<T>(string id, string partitionKeyValue, CancellationToken cancellationToken) where T : CosmosBase
        {
            var response = await Container.DeleteItemAsync<T>(id, new PartitionKey(partitionKeyValue), null, cancellationToken);

            return response.Resource;
        }
    }
}