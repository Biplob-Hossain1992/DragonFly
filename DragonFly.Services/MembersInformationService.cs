using DragonFly.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonFly.Services
{
    public class MembersInformationService : IMembersInformationRepository
    {
        private readonly IMembersInformationRepository _membersInformationRepository;

        public MembersInformationService(IMembersInformationRepository membersInformationRepository)
        {
            _membersInformationRepository = membersInformationRepository;
        }
    }
}
