using DragonFly.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonFly.Controllers
{
    [Produces("application/json")]
    [Route("api/Fetch")]
    public class FetchController : ControllerBase
    {
        private readonly IMembersInformationService _membersInformationService;
        public FetchController(IMembersInformationService membersInformationService)
        {
            _membersInformationService = membersInformationService;
        }
    }
}
