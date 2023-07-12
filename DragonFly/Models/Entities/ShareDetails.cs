using DragonFly.Models.Common;

namespace DragonFly.Models.Entities
{
    #nullable disable
    public class ShareDetails : BaseEntity<int>
    {
        public int MemberInformationId { get; set; }
        public MemberInformation MemberInformation { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int NoOfShare { get; set; }
        public decimal Amount { get; set; }
    }
}
