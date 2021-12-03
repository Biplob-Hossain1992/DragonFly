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
    [Route("api/Delete")]
    [Authorize]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly IMembersInformationService _membersInformationService;

        public DeleteController(IMembersInformationService membersInformationService)
        {
            _membersInformationService = membersInformationService;
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("DeleteMemberInfo/{mobile}")]
        public async Task<IActionResult> DeleteMemberInfo(string mobile)
        {
            var response = new SingleResponseModel<int>();
            try
            {
                var data = await _membersInformationService.DeleteMemberInfo(mobile);
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
