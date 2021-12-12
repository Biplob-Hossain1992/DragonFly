using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Services.Interfaces.Generic
{
    public interface IGenericService<T> where T : class
    {
        Task<bool> Add(T entity);
    }
}
