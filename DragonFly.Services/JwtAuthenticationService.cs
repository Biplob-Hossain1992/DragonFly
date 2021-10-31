using DragonFly.Context;
using DragonFly.Domain.Entities;
using DragonFly.Domain.Entities.ViewModel;
using DragonFly.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DragonFly.Services
{
    public class JwtAuthenticationService : IJwtAuthenticationManager
    {
        private readonly AppSettings _appSettings;
        private readonly SqlServerContext _sqlServerContext;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtAuthenticationService(IOptions<AppSettings> appSettings, SqlServerContext sqlServerContext)
        {
            _appSettings = appSettings.Value;
            _sqlServerContext = sqlServerContext;
        }

        public UsersViewModel GetToken(UsersViewModel users)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.UserId.ToString())
                    //new Claim(ClaimTypes.Role,"Practice")
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            users.Token = tokenHandler.WriteToken(token);

            users.Password = null;

            return users;
        }
    }
}
