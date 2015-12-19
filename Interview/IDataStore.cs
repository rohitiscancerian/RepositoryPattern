using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public interface IDataStore<T> : IRepository<T> where T : IStoreable
    {
    }
   
}
    