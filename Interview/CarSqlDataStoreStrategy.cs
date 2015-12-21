using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview
{
    public class CarSqlDataStoreStrategy :  SqlDataStoreStrategy<Car> , IDataStoreStrategy<Car>
    {

        public CarSqlDataStoreStrategy(IDataStoreContext dataStoreContext) : base (dataStoreContext)
        { }

        public CarSqlDataStoreStrategy() : base ()
        {

        }
    }
}
