

using keylookup.Common;
using System;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace keylookup.Infrastructure.Cache
{
    public class RedisCache : ICache
    {
        private ConnectionMultiplexer redis = null;
        private IDatabase database;
        private IConfiguration configuration;
        public RedisCache(IConfiguration configuration)
        {
            this.configuration = configuration;
            var connectionString = configuration["RedisConnectionString"];
            this.redis = ConnectionMultiplexer.Connect(connectionString);
            this.database = redis.GetDatabase();
        }

        public void Add(string requestId, string guid)
        {
            this.database.StringSet(requestId, guid);
        }

        public bool ContainsKey(string requestId)
        {
            return this.database.KeyExists(requestId);
        }

        public string Get(string requestId)
        {
            var value = this.database.StringGet(requestId);
            return value.ToString();
        }
    }
}
