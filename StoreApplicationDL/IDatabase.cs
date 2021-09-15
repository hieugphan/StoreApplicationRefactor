using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreApplicationDL
{
    public interface IDatabase<T> where T: class 
    {
        Task<T> Create(T model);
        Task<T> Delete(T model);
        Task<IList<T>> Query(QueryOptions<T> options);
        Task<T> FindSingle(QueryOptions<T> options);
        Task<T> Update(T model);
        Task<bool> Save();
    }
}
