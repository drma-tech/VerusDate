using Microsoft.Azure.Cosmos;

namespace VerusDate.Api.Repository
{
    public static class CosmosRepositoryExtensions
    {
        public static QueryRequestOptions GetDefaultOptions(string partitionKeyValue)
        {
            //TODO: specify how many items you want to return for each page of results
            //QueryRequestOptions options = new()
            //{
            //    MaxItemCount = 100
            //};

            if (string.IsNullOrEmpty(partitionKeyValue))
                return null;
            else
                return new QueryRequestOptions() { PartitionKey = new PartitionKey(partitionKeyValue) };
        }
    }
}