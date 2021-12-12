using DragonFly.Context;
using DragonFly.Domain.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Infrastructure.Data.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SqlServerContext _sqlServerContext;
        internal DbSet<T> dbSet;

        public GenericRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }
        public async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }
    }
}
