using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public class CarRepository : Repository<Car>
    {
        public CarSqlDataStoreStrategy carDataStore;

        public CarRepository(CarSqlDataStoreStrategy carDataStore) : base(carDataStore)
        {
            this.carDataStore = carDataStore;
        }

        public override void Save(Car item)
        {
            if (item.Id != null)
            { 
                base.Save(item);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }


}
