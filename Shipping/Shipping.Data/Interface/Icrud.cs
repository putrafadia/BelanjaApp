using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Data.Interface
{
    public interface Icrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T obj);
        Task<T> Update(int id, T obj);
        Task Delete(int id);
    }
}
