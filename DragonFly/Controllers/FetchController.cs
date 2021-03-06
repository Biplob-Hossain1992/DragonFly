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
    [Route("api/Fetch")]
    public class FetchController : ControllerBase
    {
        private readonly IMembersInformationService _membersInformationService;
        public FetchController(IMembersInformationService membersInformationService)
        {
            _membersInformationService = membersInformationService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetMembersInformationByMobile/{mobile}")]
        public async Task<IActionResult> GetMembersInformationByMobile(string mobile)
        {
            var response = new SingleResponseModel<MembersInformationViewModel>();
            try
            {
                var data = await _membersInformationService.GetMembersInformationByMobile(mobile);
                response.Model = data;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, Please contact to technical support";
            }

            return response.ToHttpResponse();
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetAllMembersInformation")]
        public async Task<IActionResult> GetAllMembersInformation()
        {
            var response = new ListResponseModel<MembersInformationViewModel>();
            try
            {
                var data = await _membersInformationService.GetAllMembersInformation();
                response.Model = data;
            }
            catch (Exception)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, Please contact to technical support";
            }
            return response.ToHttpResponse();
        }
    }
}
