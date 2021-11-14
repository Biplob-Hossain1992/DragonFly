using DragonFly.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonFly.Controllers
{
    [Produces("application/json")]
    [Route("api/Update")]
    [Authorize]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly IMembersInformationService _membersInformationService;
        public UpdateController(IMembersInformationService membersInformationService)
        {
            _membersInformationService = membersInformationService;
        }
    }
}
