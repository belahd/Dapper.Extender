using Dapper.Extender.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dapper.Extender
{
    public class EntityService<T> where T : EntityBase
    {
        public T Get(long id)
        {
            throw new Exception("Not Implemented");
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            throw new Exception("Not Implemented");
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> predicate = null)
        {
            throw new Exception("Not Implemented");
        }

        public IEnumerable<T> Select(long page, long size, Expression<Func<T, bool>> predicate = null)
        {
            throw new Exception("Not Implemented");
        }

        public bool Insert(T entity)
        {
            throw new Exception("Not Implemented");
        }

        public bool Insert(IEnumerable<T> entities)
        {
            throw new Exception("Not Implemented");
        }

        public bool Update(T entity)
        {
            throw new Exception("Not Implemented");
        }

        public bool Update(IEnumerable<T> entities)
        {
            throw new Exception("Not Implemented");
        }

        public bool Delete(long id)
        {
            throw new Exception("Not Implemented");
        }

        public bool Delete(Expression<Func<T, bool>> predicate)
        {
            throw new Exception("Not Implemented");
        }

        public bool Delete(T entity)
        {
            throw new Exception("Not Implemented");
        }

        public bool Delete(IEnumerable<T> entities)
        {
            throw new Exception("Not Implemented");
        }

        public long Count()
        {
            throw new Exception("Not Implemented");
        }

        public long Count(Expression<Func<T, bool>> predicate)
        {
            throw new Exception("Not Implemented");
        }
    }
}
