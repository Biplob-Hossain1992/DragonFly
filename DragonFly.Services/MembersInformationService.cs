using DragonFly.Domain.Entities.DataModel;
using DragonFly.Domain.Interfaces;
using DragonFly.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Services
{
    public class MembersInformationService : IMembersInformationService
    {
        private readonly IMembersInformationRepository _membersInformationRepository;

        public MembersInformationService(IMembersInformationRepository membersInformationRepository)
        {
            _membersInformationRepository = membersInformationRepository;
        }

        public async Task<MembersInformation> AddMembersInformation(MembersInformation members)
        {
            return await _membersInformationRepository.AddMembersInformation(members);
        }
    }
}
