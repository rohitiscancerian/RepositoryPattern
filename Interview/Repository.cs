﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;

namespace Interview
{

    public class Repository<T> : IRepository<T> where T : IStoreable
    {
        protected IDataStore<T> dataStore;

        public Repository(IDataStore<T> dataStore)
        {
            this.dataStore = dataStore;
        }

        public IEnumerable<T> All()
        {
            return this.dataStore.All();
        }

        public void Delete(IComparable id)
        {
            this.dataStore.Delete(id);
        }

        public T FindById(IComparable id)
        {
            return this.dataStore.FindById(id);
        }

        public void Save(T item)
        {
            this.dataStore.Save(item);
        }
    }
}