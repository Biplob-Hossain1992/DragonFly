using DragonFly.Models.Entities;

namespace DragonFly.Models.ViewModels
{
    public class VmShareDetails
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; } = "";
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; } = "";
        public int NoOfShare { get; set; }
        public decimal Amount { get; set; }
    }
}
