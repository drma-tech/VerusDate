using Microsoft.Azure.Cosmos;

namespace VerusDate.Api.Repository
{
    public static class CosmosRepositoryExtensions
    {
        public static QueryRequestOptions GetDefaultOptions(string partitionKeyValue)
        {
            if (string.IsNullOrEmpty(partitionKeyValue))
                return null;
            else
                return new QueryRequestOptions() { PartitionKey = new PartitionKey(partitionKeyValue) };
        }
    }
}