using keylookup.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keylookup.Application.UseCases.LookupFromCache
{
    public class LookupFromCache  
    {
        private LookupFromCacheRequest request;
        private ICache cache;
        private IGuidGenerator guidGenerator;

        public LookupFromCache(ICache cache,IGuidGenerator guidGenerator)
        {
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
            this.guidGenerator = guidGenerator ?? throw new ArgumentNullException(nameof(guidGenerator));
        }

        public LookupFromCacheResponse Execute(LookupFromCacheRequest request)
        {
            var requestId = request.Id;
            string guid;
            if (!this.cache.ContainsKey(requestId))
            {
                guid = this.guidGenerator.Generate();
                this.cache.Add(requestId, guid);
            }
            else
            {
                guid = this.cache.Get(requestId);
            }
            return new LookupFromCacheResponse(guid);
        }
    }
}
