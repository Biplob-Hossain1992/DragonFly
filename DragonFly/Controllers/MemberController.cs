using DragonFly.Context;
using DragonFly.Models.Entities;
using DragonFly.Models.Helper;
using DragonFly.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace DragonFly.Controllers
{
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MemberController(ApplicationDbContext dbContext)
        {
                _db = dbContext;
        }
        public IActionResult MemberDetails()
        {
            return View();
        }
        public IActionResult ShareDetails()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VmMemberInformation vmMember)
        {
            var response = new VmResponseMessage();
            var dateOfBirth = Convert.ToDateTime(vmMember.DateOfBirth);
            if (vmMember.Id == 0)
            {
                var model = new MemberInformation
                {
                    NameInEnglish = vmMember.NameInEnglish,
                    NameInBangla = vmMember.NameInBangla,
                    DateOfBirth = dateOfBirth,
                    NIDNumber = vmMember.NIDNumber,
                    Phone = vmMember.Phone,
                    Email = vmMember.Email,
                    Address = vmMember.Address
                };
                await _db.MemberInformation.AddAsync(model);
                await _db.SaveChangesAsync();                
                response.Message = "Created Successfully..!!";
            }
            else
            {
                var entity = await _db.MemberInformation.FirstOrDefaultAsync(x => x.Id == vmMember.Id);
                if (entity is not null)
                {
                    entity.NameInEnglish = vmMember.NameInEnglish;
                    entity.NameInBangla = vmMember.NameInBangla;
                    entity.DateOfBirth = dateOfBirth;
                    entity.NIDNumber = vmMember.NIDNumber;
                    entity.Phone = vmMember.Phone;
                    entity.Email = vmMember.Email;
                    entity.Address = vmMember.Address;
                    _db.MemberInformation.Update(entity);
                    await _db.SaveChangesAsync();
                    response.Message = "Updated Successfully..!!";
                }
            }
            response.Type = "Success";
            return Json(response);
        }
        [HttpGet]
        public async Task<ActionResult<List<VmMemberInformation>>> GetAllMembers()
        {
            var memberList = await _db.MemberInformation
                                      .Select(x => new VmMemberInformation
                                      {
                                          Id = x.Id,
                                          NameInEnglish = x.NameInEnglish,
                                          NameInBangla = x.NameInBangla,
                                          DateOfBirth = x.DateOfBirth.ToString("dd MMM yyyy"),
                                          NIDNumber = x.NIDNumber,
                                          Phone = x.Phone,
                                          Email = x.Email,
                                          Address = x.Address
                                      }).ToListAsync();
            return Json(memberList);
        }
        [HttpPost]
        public async Task<IActionResult> CreateShare(VmShareDetails vmShare)
        {
            var response = new VmResponseMessage();
            if (vmShare.Id == 0)
            {
                var model = new ShareDetails
                {
                    MemberInformationId = vmShare.MemberId,
                    Year = vmShare.Year,
                    Month = vmShare.Month,
                    NoOfShare = vmShare.NoOfShare,
                    Amount = vmShare.Amount
                };
                await _db.ShareDetails.AddAsync(model);
                await _db.SaveChangesAsync();
                response.Message = "Created Successfully..!!";
            }
            else
            {
                var entity = await _db.ShareDetails.FirstOrDefaultAsync(x => x.Id == vmShare.Id);
                if (entity is not null)
                {
                    entity.MemberInformationId = vmShare.MemberId;
                    entity.Year = vmShare.Year;
                    entity.Month = vmShare.Month;
                    entity.NoOfShare = vmShare.NoOfShare;
                    entity.Amount = vmShare.Amount;
                    _db.ShareDetails.Update(entity);
                    await _db.SaveChangesAsync();
                    response.Message = "Updated Successfully..!!";
                }
            }
            response.Type = "Success";
            return Json(response);
        }
        [HttpGet]
        public async Task<ActionResult<List<VmShareDetails>>> GetAllShares()
        {
            var shareList = await _db.ShareDetails
                                     .Include(x => x.MemberInformation)
                                     .Select(x => new VmShareDetails
                                     {
                                         Id = x.Id,
                                         MemberId = x.MemberInformationId,
                                         MemberName = x.MemberInformation.NameInEnglish,
                                         Year = x.Year,
                                         Month = x.Month,
                                         MonthName = x.Month.GetMonthName(),
                                         NoOfShare = x.NoOfShare,
                                         Amount = x.Amount
                                     }).ToListAsync();
            return Json(shareList);
        }
    }
}
