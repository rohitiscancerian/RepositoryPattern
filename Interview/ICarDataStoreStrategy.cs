using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public interface ICarDataStoreStrategy : IDataStoreStrategy<Car> , ICarRepository
    {
    }
}
