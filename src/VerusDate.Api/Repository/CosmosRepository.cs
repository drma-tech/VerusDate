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

        public async Task<T> Get<T>(string id, PartitionKey key, CancellationToken cancellationToken) where T : CosmosBase
        {
            try
            {
                var response = await Container.ReadItemAsync<T>(id, key, null, cancellationToken);

                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<T> Get<T>(QueryDefinition query, CancellationToken cancellationToken) where T : class
        {
            using (var iterator = Container.GetItemQueryIterator<T>(query))
            {
                T result = null;

                while (iterator.HasMoreResults)
                {
                    foreach (var item in await iterator.ReadNextAsync(cancellationToken))
                    {
                        result = item;
                    }
                }

                return result;
            }
        }

        public async Task<List<T>> Query<T>(Expression<Func<T, bool>> predicate, string partitionKeyValue, CosmosType Type, CancellationToken cancellationToken) where T : CosmosBase
        {
            IQueryable<T> query;

            if (predicate is null)
            {
                query = Container.GetItemLinqQueryable<T>(requestOptions: CosmosRepositoryExtensions.GetDefaultOptions(partitionKeyValue))
                    .Where(item => item.Type == Type);
            }
            else
            {
                query = Container.GetItemLinqQueryable<T>(requestOptions: CosmosRepositoryExtensions.GetDefaultOptions(partitionKeyValue))
                    .Where(predicate.Compose(item => item.Type == Type, Expression.AndAlso));
            }

            using (var iterator = query.ToFeedIterator())
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

        public async Task<List<T>> Query<T>(QueryDefinition query, CancellationToken cancellationToken) where T : CosmosBaseQuery
        {
            using (var iterator = Container.GetItemQueryIterator<T>(query))
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

        public async Task<T> Add<T>(T item, CancellationToken cancellationToken) where T : CosmosBase
        {
            var response = await Container.CreateItemAsync(item, new PartitionKey(item.Key), null, cancellationToken);

            return response.Resource;
        }

        public async Task<T> Update<T>(T item, CancellationToken cancellationToken) where T : CosmosBase
        {
            var response = await Container.ReplaceItemAsync(item, item.Id, new PartitionKey(item.Key), null, cancellationToken);

            return response.Resource;
        }

        public async Task<T> Delete<T>(string id, PartitionKey key, CancellationToken cancellationToken) where T : CosmosBase
        {
            var response = await Container.DeleteItemAsync<T>(id, key, null, cancellationToken);

            return response.Resource;
        }
    }
}