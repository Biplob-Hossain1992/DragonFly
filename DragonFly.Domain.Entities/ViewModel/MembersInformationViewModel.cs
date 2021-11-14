using System;
using System.Collections.Generic;
using System.Text;

namespace DragonFly.Domain.Entities.ViewModel
{
    public class MembersInformationViewModel
    {
        public int MembersInformationId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int Share { get; set; }
        public decimal Amount { get; set; }
    }
}
