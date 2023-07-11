using DragonFly.Models.Common;

namespace DragonFly.Models.Entities
{
    public class MemberInformation : BaseEntity<int>
    {
        public string NameInEnglish { get; set; } = "";
        public string NameInBangla { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public string NIDNumber { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
