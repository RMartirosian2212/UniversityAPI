using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Models.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Post(T student);
        Task<T> Put(T student);
        Task Delete(int id);
        Task Save();

    }
}
