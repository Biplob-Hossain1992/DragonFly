using DragonFly.Domain.Entities.DataModel;
using DragonFly.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Services.Interfaces
{
    public interface IMembersInformationService
    {
        Task<MembersInformation> AddMembersInformation(MembersInformation members);
        Task<List<MembersInformation>> AddMultipleMembersInformation(List<MembersInformation> membersInformation);
        Task<MembersInformationViewModel> GetMembersInformationByMobile(string mobile);
        Task<IEnumerable<MembersInformationViewModel>> GetAllMembersInformation();
        Task<MembersInformation> UpdateMemberInformation(MembersInformation members);
    }
}
