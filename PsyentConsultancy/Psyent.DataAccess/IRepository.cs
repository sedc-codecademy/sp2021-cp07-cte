using System.Collections.Generic;

namespace Psyent.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
