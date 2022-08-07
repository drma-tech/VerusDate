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
using VerusDate.Shared.Helper;

namespace VerusDate.Api.Repository
{
    public class CosmosRepository : IRepository
    {
        public Container Container { get; private set; }

        private const double ru_limit_get = 3;
        private const double ru_limit_query = 5;
        private const double ru_limit_save = 30; //TODO: DECREASE THIS VALUE

        public CosmosRepository(IConfiguration config)
        {
            var connString = config.GetValue<string>("RepositoryOptions_CosmosConnectionString");
            var databaseId = config.GetValue<string>("RepositoryOptions_DatabaseId");
            var containerId = config.GetValue<string>("RepositoryOptions_ContainerId");

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
            try
            {
                var response = await Container.ReadItemAsync<T>(id, new PartitionKey(partitionKeyValue), null, cancellationToken);

                if (response.RequestCharge > ru_limit_get) throw new NotificationException("RU limit exceeded");

                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<T> Get<T>(QueryDefinition query, string partitionKeyValue, CancellationToken cancellationToken) where T : class
        {
            using var iterator = Container.GetItemQueryIterator<T>(query, requestOptions: CosmosRepositoryExtensions.GetDefaultOptions(partitionKeyValue));

            if (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync(cancellationToken);

                if (response.RequestCharge > ru_limit_get) throw new NotificationException("RU limit exceeded");

                return response.Resource.FirstOrDefault();
            }
            else
            {
                return null;
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

            using var iterator = query.ToFeedIterator();
            List<T> results = new List<T>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync(cancellationToken);

                if (response.RequestCharge > ru_limit_query) throw new NotificationException("RU limit exceeded");

                results.AddRange(response.Resource);
            }

            return results;
        }

        public async Task<List<T>> Query<T>(QueryDefinition query, CancellationToken cancellationToken) where T : CosmosBaseQuery
        {
            using var iterator = Container.GetItemQueryIterator<T>(query);
            List<T> results = new List<T>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync(cancellationToken);

                if (response.RequestCharge > ru_limit_query) throw new NotificationException($"RU limit exceeded ({response.RequestCharge})");

                results.AddRange(response.Resource);
            }

            return results;
        }

        public async Task<T> Add<T>(T item, CancellationToken cancellationToken) where T : CosmosBase
        {
            var response = await Container.CreateItemAsync(item, new PartitionKey(item.Key), null, cancellationToken);

            if (response.RequestCharge > ru_limit_save) throw new NotificationException($"RU limit exceeded ({response.RequestCharge})");

            return response.Resource;
        }

        public async Task<bool> Update<T>(T item, CancellationToken cancellationToken) where T : CosmosBase
        {
            var response = await Container.ReplaceItemAsync(item, item.Id, new PartitionKey(item.Key), null, cancellationToken);

            if (response.RequestCharge > ru_limit_save) throw new NotificationException($"RU limit exceeded ({response.RequestCharge})");

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}