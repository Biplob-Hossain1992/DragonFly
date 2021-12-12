using DragonFly.Domain.Interfaces.Generic;
using DragonFly.Services.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Services.Generic
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<bool> Add(T entity)
        {
            return await _genericRepository.Add(entity);
        }
    }
}
