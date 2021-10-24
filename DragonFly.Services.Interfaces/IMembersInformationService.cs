using DragonFly.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Services.Interfaces
{
    public interface IMembersInformationService
    {
        Task<MembersInformation> AddMembersInformation(MembersInformation members);
    }
}
