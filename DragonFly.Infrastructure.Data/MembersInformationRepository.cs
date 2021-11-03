using Dapper;
using DragonFly.Context;
using DragonFly.Domain.Entities;
using DragonFly.Domain.Entities.DataModel;
using DragonFly.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonFly.Infrastructure.Data
{
    public class MembersInformationRepository: IMembersInformationRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ConnectionString _connectionStrings;
        public MembersInformationRepository(SqlServerContext sqlServerContext, IHttpContextAccessor httpContextAccessor,
            IOptions<ConnectionString> connectionStrings)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
            _httpContextAccessor = httpContextAccessor;
            _connectionStrings = connectionStrings.Value;
        }

        public async Task<MembersInformation> AddMembersInformation(MembersInformation members)
        {
            await _sqlServerContext.MembersInformation.AddAsync(members);
            await _sqlServerContext.SaveChangesAsync();
            return members;
        }

        public async Task<IEnumerable<MembersInformation>> GetAllMembersInformation(string mobile)
        {
            using (var connection = new SqlConnection(_connectionStrings.MsSqlConnection))
            {
                connection.Open();

                var parameter = new DynamicParameters();
                parameter.Add(name: "@Mobile", value: mobile, dbType: DbType.String);

                var data = await connection.QueryAsync<MembersInformation>(
                        sql: @"[USP_GetAllMembersInformation]",
                        param: parameter,
                        commandType: CommandType.StoredProcedure);

                return data;
            }
        }
    }
}
