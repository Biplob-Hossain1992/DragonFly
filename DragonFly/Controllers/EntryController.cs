﻿using DragonFly.Domain.Entities.DataModel;
using DragonFly.Domain.Entities.ViewModel;
using DragonFly.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonFly.Controllers
{
    public class EntryController : ControllerBase
    {
        private readonly IMembersInformationService _membersInformationService;
        public EntryController(IMembersInformationService membersInformationService)
        {
            _membersInformationService = membersInformationService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [AllowAnonymous]
        [Route("AddMembersInformation")]
        public async Task<IActionResult> AddMembersInformation([FromBody] MembersInformation members)
        {
            var response = new SingleResponseModel<MembersInformation>();
            try
            {
                var data = await _membersInformationService.AddMembersInformation(members);
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