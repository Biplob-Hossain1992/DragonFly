using DragonFly.Services.Interfaces.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonFly.Controllers.Generic
{
    [Produces("application/json")]
    [Route("api/Entry")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        //private readonly IGenericService _genericService;

        //public EntryController(IGenericService genericService)
        //{
        //    _genericService = genericService;
        //}
    }
}
