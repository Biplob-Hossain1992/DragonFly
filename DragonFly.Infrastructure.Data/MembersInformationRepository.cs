using Dapper;
using DragonFly.Context;
using DragonFly.Domain.Entities;
using DragonFly.Domain.Entities.DataModel;
using DragonFly.Domain.Entities.ViewModel;
using DragonFly.Domain.Interfaces;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<MembersInformation>> AddMultipleMembersInformation(List<MembersInformation> membersInformation)
        {
            await _sqlServerContext.MembersInformation.AddRangeAsync(membersInformation);
            await _sqlServerContext.SaveChangesAsync();
            return membersInformation;
        }

        public async Task<MembersInformationViewModel> GetMembersInformationByMobile(string mobile)
        {
            using (var connection = new SqlConnection(_connectionStrings.MsSqlConnection))
            {
                connection.Open();

                var parameter = new DynamicParameters();
                parameter.Add(name: "@Mobile", value: mobile, dbType: DbType.String);

                var data = await connection.QueryAsync<MembersInformationViewModel>(
                        sql: @"[USP_GetAllMembersInformation]",
                        param: parameter,
                        commandType: CommandType.StoredProcedure);

                return data.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<MembersInformationViewModel>> GetAllMembersInformation()
        {
            return await _sqlServerContext.MembersInformation
                .Select(x => new MembersInformationViewModel
                {
                    Name = x.Name,
                    Mobile = x.Mobile,
                    Address = x.Address,
                    Share = x.Share,
                    Amount = x.Amount
                }).ToListAsync();
        }

        public async Task<MembersInformation> UpdateMemberInformation(MembersInformation members)
        {
            var entity = await _sqlServerContext.MembersInformation.FirstOrDefaultAsync(b => b.Mobile == members.Mobile);

            if(entity != null)
            {
                entity.Name = members.Name;
                entity.Address = members.Address;
                entity.Share = members.Share;
                entity.Amount = members.Amount;

                if(_sqlServerContext.Entry(entity).State != EntityState.Unchanged)
                {
                    _sqlServerContext.Update(entity);
                    await _sqlServerContext.SaveChangesAsync();
                }
                return entity;
            }
            return null;
        }

        //this bulk update will work properly when share and amount will be the same for all objects
        public async Task<int> UpdateBulkMembersInfo(List<MembersInformation> members)
        {
            var mobileNumbers = (from d in members
                                 select d.Mobile).ToArray();

            var entity = await _sqlServerContext.MembersInformation.AsNoTracking().Where(b => mobileNumbers.Contains(b.Mobile))
                        .BatchUpdateAsync(x => new MembersInformation
                        {
                            Share = members.FirstOrDefault().Share,
                            Amount = members.FirstOrDefault().Amount
                        });

            if (entity > 0)
            {
                return 1;
            }   
            return 0;
        }

        //this bulk update for all object with diferrent value 
        public async Task<int> UpdateBulkWithDiferrentValue(List<MembersInformation> members)
        {
            var mobileArray = members.Select(m => m.Mobile).ToArray();
            //var mobile = (from m in members
                         //select m.Mobile).ToArray();

            var data = _sqlServerContext.MembersInformation.Where(x => mobileArray.Contains(x.Mobile));

            foreach (var item in data)
            {
                var modifyRequestBody = members.Where(m => m.Mobile.Equals(item.Mobile)).FirstOrDefault();

                item.Share = modifyRequestBody.Share;
                item.Amount = modifyRequestBody.Amount;

                _sqlServerContext.MembersInformation.Update(item);
            }
            var entity = await _sqlServerContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> DeleteMemberInfo(string mobile)
        {
            var entity = await _sqlServerContext.MembersInformation.FirstOrDefaultAsync(m => m.Mobile.Equals(mobile));
            if(entity != null)
            {
                _sqlServerContext.MembersInformation.Remove(entity);
                return await _sqlServerContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
