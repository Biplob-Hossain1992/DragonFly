using DragonFly.Domain.Entities;
using DragonFly.Domain.Entities.DataModel;
using DragonFly.Domain.Entities.ViewModel;
using DragonFly.Domain.Interfaces;
using DragonFly.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AppSettings _appSettings;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public AccountService(IAccountRepository accountRepository,
            IOptions<AppSettings> appSettings,
            IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _accountRepository = accountRepository;
            _appSettings = appSettings.Value;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }
        public async Task<UsersViewModel> AdminUserLogin(Users user)
        {

            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.UserName))
                return null;

            var data = await _accountRepository.AdminUserLogin(user);

            if (data == null)
                return null;


            var userToekn = _jwtAuthenticationManager.GetToken(data);

            return userToekn;
        }
    }
}
