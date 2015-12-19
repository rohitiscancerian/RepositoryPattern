using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public class CarRepository : Repository<Car>
    {
        public IDataStore<Car> carDataStore;

        public  CarRepository(IDataStore<Car> carDataStore) : base (carDataStore)
        {
            this.carDataStore = carDataStore;
        }
    }

   
}
