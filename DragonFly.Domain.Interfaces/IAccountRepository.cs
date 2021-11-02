using DragonFly.Domain.Entities.DataModel;
using DragonFly.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<UsersViewModel> AdminUserLogin(Users user);
    }
}
