using DragonFly.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DragonFly.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
        {
                
        }
        //public DbSet<Test> Test { get; set; }
        public DbSet<MemberInformation> MemberInformation { get; set; }
    }
}
