using keylookup.Common;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keylookup.Infrastructure.Cache
{
    public class InMemoryCache : ICache
    {
        private Dictionary<string, string> cache = new Dictionary<string, string>();
        public InMemoryCache()
        {

        }
      
        public void Add(string requestId, string guid)
        {
            cache.Add(requestId, guid);
        }

        public bool ContainsKey(string requestId)
        {
            return cache.ContainsKey(requestId);
        }

        public string Get(string requestId)
        {
            return cache[requestId];
        }
    }
}
