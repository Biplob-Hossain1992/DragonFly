using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Domain.Interfaces.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Add(T entity);
    }
}
