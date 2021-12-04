using DragonFly.Domain.Entities.DataModel;
using DragonFly.Domain.Entities.ViewModel;
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

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateMemberInformation")]
        public async Task<IActionResult> UpdateMemberInformation([FromBody] MembersInformation members)
        {
            var response = new SingleResponseModel<MembersInformation>();
            try
            {
                var data = await _membersInformationService.UpdateMemberInformation(members);
                response.Model = data;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.InnerException.Message.ToString();
            }

            return response.ToHttpCreatedResponse();
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateBulkMembersInfo")]
        public async Task<IActionResult> UpdateBulkMembersInfo([FromBody] List<MembersInformation> members)
        {
            var response = new SingleResponseModel<int>();
            try
            {
                var data = await _membersInformationService.UpdateBulkMembersInfo(members);
                response.Model = data;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.InnerException.Message.ToString();
            }

            return response.ToHttpCreatedResponse();
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateBulkWithDiferrentValue")]
        public async Task<IActionResult> UpdateBulkWithDiferrentValue([FromBody] List<MembersInformation> members)
        {
            var response = new SingleResponseModel<int>();
            try
            {
                var data = await _membersInformationService.UpdateBulkWithDiferrentValue(members);
                response.Model = data;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.InnerException.Message.ToString();
            }

            return response.ToHttpCreatedResponse();
        }
    }
}
