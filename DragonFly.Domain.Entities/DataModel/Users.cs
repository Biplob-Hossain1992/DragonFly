using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DragonFly.Domain.Entities.DataModel
{
    [Table("Users", Schema = "dbo")]
    public class Users
    {
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.Now;
        public int PostedBy { get; set; }
        public byte AdminType { get; set; }
        public bool IsActive { get; set; }
        public int UpdatedBy { get; set; }
        public string PersonalEmail { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
