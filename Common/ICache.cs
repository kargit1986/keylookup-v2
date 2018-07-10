using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keylookup.Common
{
    public interface ICache
    {
        bool ContainsKey(string requestId);
        string Get(string requestId);
        void Add(string requestId, string guid);
    }
}
