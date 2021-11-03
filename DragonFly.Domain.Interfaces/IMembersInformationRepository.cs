using DragonFly.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Domain.Interfaces
{
    public interface IMembersInformationRepository
    {
        Task<MembersInformation> AddMembersInformation(MembersInformation members);
        Task<IEnumerable<MembersInformation>> GetAllMembersInformation(string mobile);
    }
}
