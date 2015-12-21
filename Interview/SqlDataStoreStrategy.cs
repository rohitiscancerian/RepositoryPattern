using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;

namespace Interview
{
    public class SqlDataStoreStrategy<T> : IDataStoreStrategy<T>
        where T : class, IStoreable
    {
        protected readonly SqlDataStoreContext dataContext;

        public readonly DbSet<T> dbSet;

        public SqlDataStoreStrategy(IDataStoreContext dataContext)
        {
            // Since this is a specific implementation for Sql it does know about the existence of SqlDataStoreContext
            this.dataContext = dataContext as SqlDataStoreContext;
            this.dbSet = this.dataContext.Set<T>();
        }

        public SqlDataStoreStrategy()
        {

        }

        public virtual IEnumerable<T> All()
        {
            return this.dbSet.ToList();
        }

        public virtual void Delete(IComparable id)
        {
            var entity = this.dbSet.Find(id);
            this.dbSet.Remove(entity);
        }

        public virtual T FindById(IComparable id)
        {
            return this.dbSet.Find(id);
        }

        public virtual void Save(T item)
        {
            this.dbSet.Add(item);
        }

    }
}
