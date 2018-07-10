using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keylookup.Application.UseCases.LookupFromCache
{
    public class LookupFromCacheResponse
    {
        public string Guid { get; set; }

        public LookupFromCacheResponse(string guid)
        {
            this.Guid = guid;
        }
    }
}
