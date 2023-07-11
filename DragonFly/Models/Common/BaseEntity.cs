using System.ComponentModel.DataAnnotations;

namespace DragonFly.Models.Common
{
    #nullable disable
    public class BaseEntity<TKey> : IHasKey<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
