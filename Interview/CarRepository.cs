using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public class CarRepository : Repository<Car>
    {
        public IDataStoreStrategy<Car> carDataStore;

        public  CarRepository(IDataStoreStrategy<Car> carDataStore) : base (carDataStore)
        {
            this.carDataStore = carDataStore;
        }


    }

   
}
