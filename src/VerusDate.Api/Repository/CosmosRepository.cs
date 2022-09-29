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

        private const double ru_limit_get = 1.5;
        private const double ru_limit_query = 3;
        private const double ru_limit_save = 30;

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

            //Database database = await client.CreateDatabaseIfNotExistsAsync("cosmicworks");

            //Container container = await database.CreateContainerIfNotExistsAsync(
            //    "cosmicworks",
            //    "/categoryId",
            //    400
            //);

            //IndexingPolicy policy = new()
            //{
            //    IndexingMode = IndexingMode.Consistent,
            //    Automatic = true
            //};
            //policy.ExcludedPaths.Add(
            //    new ExcludedPath { Path = "/name/?" }
            //);

            //ContainerProperties options = new()
            //{
            //    Id = "products",
            //    PartitionKeyPath = "/categoryId",
            //    IndexingPolicy = policy
            //};
            //Container container = await database.CreateContainerIfNotExistsAsync(options, throughput: 400);
        }

        public async Task<T> Get<T>(string id, string partitionKeyValue, CancellationToken cancellationToken) where T : CosmosBase
        {
            try
            {
                var response = await Container.ReadItemAsync<T>(id, new PartitionKey(partitionKeyValue), null, cancellationToken);

                if (response.RequestCharge > ru_limit_get) throw new NotificationException($"RU limit exceeded get ({response.RequestCharge})");

                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
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
            var results = new List<T>();
            double count = 0;

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync(cancellationToken);

                count += response.RequestCharge;
                if (count > ru_limit_query) throw new NotificationException($"RU limit exceeded query ({response.RequestCharge})");

                results.AddRange(response.Resource);
            }

            return results;
        }

        public async Task<List<T>> Query<T>(QueryDefinition query, CancellationToken cancellationToken) where T : CosmosBaseQuery
        {
            using var iterator = Container.GetItemQueryIterator<T>(query);
            var results = new List<T>();
            double count = 0;

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync(cancellationToken);

                count += response.RequestCharge;
                if (count > ru_limit_query) throw new NotificationException($"RU limit exceeded query ({response.RequestCharge})");

                results.AddRange(response.Resource);
            }

            return results;
        }

        public async Task<T> Add<T>(T item, CancellationToken cancellationToken) where T : CosmosBase
        {
            var response = await Container.CreateItemAsync(item, new PartitionKey(item.Key), null, cancellationToken);

            if (response.RequestCharge > ru_limit_save) throw new NotificationException($"RU limit exceeded save ({response.RequestCharge})");

            return response.Resource;
        }

        public async Task<T> Update<T>(T item, CancellationToken cancellationToken) where T : CosmosBase
        {
            //TODO: validate concurrent update conflicts
            //string eTag = response.ETag;
            //var options = new ItemRequestOptions { IfMatchEtag = eTag };
            //await Container.UpsertItemAsync<T>(item, new PartitionKey(item.Key), requestOptions: options);

            var response = await Container.ReplaceItemAsync(item, item.Id, new PartitionKey(item.Key), null, cancellationToken);

            if (response.RequestCharge > ru_limit_save) throw new NotificationException($"RU limit exceeded save ({response.RequestCharge})");

            return response.Resource;
        }

        public async Task<T> PatchItem<T>(string id, string partitionKeyValue, List<PatchOperation> operations, CancellationToken cancellationToken) where T : CosmosBase
        {
            //https://learn.microsoft.com/en-us/azure/cosmos-db/partial-document-update-getting-started?tabs=dotnet

            var response = await Container.PatchItemAsync<T>(id, new PartitionKey(partitionKeyValue), operations, null, cancellationToken);

            if (response.RequestCharge > ru_limit_save) throw new NotificationException($"RU limit exceeded save ({response.RequestCharge})");

            return response.Resource;
        }

        public async Task<bool> Delete<T>(T item, CancellationToken cancellationToken) where T : CosmosBase
        {
            var response = await Container.DeleteItemAsync<T>(item.Id, new PartitionKey(item.Key), null, cancellationToken);

            if (response.RequestCharge > ru_limit_save) throw new NotificationException($"RU limit exceeded save ({response.RequestCharge})");

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        //multiple transactions
        //https://docs.microsoft.com/pt-br/learn/modules/perform-cross-document-transactional-operations-azure-cosmos-db-sql-api/2-create-transactional-batch-sdk

        //bulk insert
        //https://docs.microsoft.com/pt-br/learn/modules/process-bulk-data-azure-cosmos-db-sql-api/2-create-bulk-operations-sdk

        //composite indexes
        //https://docs.microsoft.com/pt-br/learn/modules/customize-indexes-azure-cosmos-db-sql-api/3-evaluate-composite-indexes
    }

    public static class CosmosRepositoryExtensions
    {
        public static QueryRequestOptions GetDefaultOptions(string partitionKeyValue)
        {
            if (string.IsNullOrEmpty(partitionKeyValue))
                return null;
            else
                return new QueryRequestOptions()
                {
                    PartitionKey = new PartitionKey(partitionKeyValue),
                    //https://learn.microsoft.com/en-us/training/modules/measure-index-azure-cosmos-db-sql-api/4-measure-query-cost
                    MaxItemCount = 10, //max itens per page
                    //https://learn.microsoft.com/en-us/training/modules/measure-index-azure-cosmos-db-sql-api/2-enable-indexing-metrics
                    PopulateIndexMetrics = false //enable only when analysing metrics
                };
        }
    }
}