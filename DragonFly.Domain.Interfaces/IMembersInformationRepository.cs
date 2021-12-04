using DragonFly.Domain.Entities.DataModel;
using DragonFly.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Domain.Interfaces
{
    public interface IMembersInformationRepository
    {
        Task<MembersInformation> AddMembersInformation(MembersInformation members);
        Task<List<MembersInformation>> AddMultipleMembersInformation(List<MembersInformation> membersInformation);
        Task<MembersInformationViewModel> GetMembersInformationByMobile(string mobile);
        Task<IEnumerable<MembersInformationViewModel>> GetAllMembersInformation();
        Task<MembersInformation> UpdateMemberInformation(MembersInformation members);
        Task<int> UpdateBulkMembersInfo(List<MembersInformation> members);
        Task<int> UpdateBulkWithDiferrentValue(List<MembersInformation> members);
        Task<int> DeleteMemberInfo(string mobile);
    }
}
