using DragonFly.Context;
using DragonFly.Domain.Entities.DataModel;
using DragonFly.Domain.Entities.ViewModel;
using DragonFly.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Infrastructure.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public AccountRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }

        public async Task<UsersViewModel> AdminUserLogin(Users user)
        {

            IQueryable<UsersViewModel> response = from c in _sqlServerContext.Users
                                                       where c.UserName.Equals(user.UserName)
                                                       && c.Password.Equals(user.Password)
                                                       && c.IsActive == true
                                                       select new UsersViewModel
                                                       {
                                                           UserId = c.UserId,
                                                           FullName = c.FullName,
                                                           IsActive = c.IsActive,
                                                           UserName = c.UserName,
                                                           Password = c.Password,
                                                           AdminType = c.AdminType,
                                                           Mobile = c.Mobile
                                                       };
            return await response.FirstOrDefaultAsync();

        }
    }
}
