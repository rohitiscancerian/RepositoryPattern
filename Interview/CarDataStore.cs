using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview
{
    class CarDataStore : IDataStore<Car>
    {
        public IEnumerable<Car> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(IComparable id)
        {
            throw new NotImplementedException();
        }

        public Car FindById(IComparable id)
        {
            throw new NotImplementedException();
        }

        public void Save(Car item)
        {
            throw new NotImplementedException();
        }
    }
}
