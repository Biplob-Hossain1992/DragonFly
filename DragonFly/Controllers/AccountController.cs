using DragonFly.Domain.Entities.DataModel;
using DragonFly.Domain.Entities.ViewModel;
using DragonFly.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonFly.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public AccountController(IAccountService accountService, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _accountService = accountService;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("AdminUserLogin")]
        public async Task<IActionResult> AdminUserLogin([FromBody] Users user)
        {
            var response = new SingleResponseModel<UsersViewModel>();

            try
            {
                var data = await _accountService.AdminUserLogin(user);
                response.Model = data;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }
            return response.ToHttpResponse();

        }
    }
}
