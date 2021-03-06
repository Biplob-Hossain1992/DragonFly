using DragonFly.Domain.Entities.DataModel;
using DragonFly.Domain.Entities.ViewModel;
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
        public async Task<List<MembersInformation>> AddMultipleMembersInformation(List<MembersInformation> membersInformation)
        {
            return await _membersInformationRepository.AddMultipleMembersInformation(membersInformation);
        }

        public async Task<MembersInformationViewModel> GetMembersInformationByMobile(string mobile)
        {
            return await _membersInformationRepository.GetMembersInformationByMobile(mobile);
        }

        public async Task<IEnumerable<MembersInformationViewModel>> GetAllMembersInformation()
        {
            return await _membersInformationRepository.GetAllMembersInformation();
        }

        public async Task<MembersInformation> UpdateMemberInformation(MembersInformation members)
        {
            return await _membersInformationRepository.UpdateMemberInformation(members);
        }

        public async Task<int> UpdateBulkMembersInfo(List<MembersInformation> members)
        {
            return await _membersInformationRepository.UpdateBulkMembersInfo(members);
        }

        public async Task<int> UpdateBulkWithDiferrentValue(List<MembersInformation> members)
        {
            return await _membersInformationRepository.UpdateBulkWithDiferrentValue(members);
        }

        public async Task<int> DeleteMemberInfo(string mobile)
        {
            return await _membersInformationRepository.DeleteMemberInfo(mobile);
        }
    }
}
