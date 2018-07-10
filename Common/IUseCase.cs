using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keylookup.Common
{
    public interface IUseCase<TRequest,TResponse>
    {
        TResponse Execute();
    }
}
