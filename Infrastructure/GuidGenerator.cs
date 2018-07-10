using keylookup.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keylookup.Infrastructure
{
    public class GuidGenerator : IGuidGenerator
    {
        public string Generate()
        {
            var guid = Guid.NewGuid().ToString();
            var bytes = Encoding.UTF8.GetBytes(guid);
            var base64 = Convert.ToBase64String(bytes);
            return base64;
        }
    }
}
