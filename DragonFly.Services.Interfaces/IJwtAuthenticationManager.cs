using DragonFly.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonFly.Services.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        UsersViewModel GetToken(UsersViewModel usersViewModel);
    }
}
