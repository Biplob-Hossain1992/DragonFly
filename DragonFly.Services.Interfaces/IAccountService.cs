using DragonFly.Domain.Entities.DataModel;
using DragonFly.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Services.Interfaces
{
    public interface IAccountService
    {
        Task<UsersViewModel> AdminUserLogin(Users user);
    }
}
