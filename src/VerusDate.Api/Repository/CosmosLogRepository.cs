using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Repository
{
    public class LogContainer
    {
        public LogContainer()
        {
            Id = Guid.NewGuid().ToString();
            Key = DateTime.UtcNow.ToShortDateString();
        }

        public string Id { get; set; }
        public string Key { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
    }

    public class CosmosLogRepository
    {
        public Container Container { get; private set; }

        public CosmosLogRepository(IConfiguration config)
        {
            var connString = config.GetValue<string>("RepositoryOptions:CosmosConnectionString");
            var databaseId = config.GetValue<string>("RepositoryOptions:DatabaseId");
            var containerId = config.GetValue<string>("RepositoryOptions:ContainerLogId");

            var _client = new CosmosClient(connString, new CosmosClientOptions()
            {
                SerializerOptions = new CosmosSerializationOptions()
                {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                }
            });

            Container = _client.GetContainer(databaseId, containerId);
        }

        public async Task Add(LogContainer log, CancellationToken cancellationToken)
        {
            await Container.CreateItemAsync(log, new PartitionKey(log.Key), null, cancellationToken);
        }
    }
}