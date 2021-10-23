using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DragonFly.Domain.Entities.DataModel
{
    [Table("MembersInformation", Schema = "dbo")]
    public class MembersInformation
    {
        [Key]
        [Column("MembersInformationId")]
        public int MembersInformationId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int Share { get; set; }
        public decimal Amount { get; set; }
    }
}
