using DragonFly.Domain.Entities.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonFly.Context
{
    public class SqlServerContext: DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
            //if base(options) don't use then show below error

            //No database provider has been configured for this DbContext.
            //A provider can be configured by overriding the DbContext.OnConfiguring method or by using AddDbContext on the application service provider.
            //If AddDbContext is used, then also ensure that your DbContext type accepts a DbContextOptions<TContext> object in its constructor
            //and passes it to the base constructor for DbContext.
        }

        public DbSet<MembersInformation> MembersInformation { get; set; }
    }
}
