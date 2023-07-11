using DragonFly.Context;
using DragonFly.Models.Entities;
using DragonFly.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost]
        public async Task<IActionResult> Create(VmMemberInformation vmMember)
        {
            var response = new VmResponseMessage();
            var model = new MemberInformation
            {
                NameInEnglish = vmMember.NameInEnglish,
                NameInBangla = vmMember.NameInBangla,
                DateOfBirth = Convert.ToDateTime(vmMember.DateOfBirth),
                NIDNumber = vmMember.NIDNumber,
                Phone = vmMember.Phone,
                Email = vmMember.Email,
                Address = vmMember.Address
            };
            await _db.AddAsync(model);
            await _db.SaveChangesAsync();
            response.Type = "Success";
            response.Message = "Created Successfully..!!";
            return Json(response);
        }
        public async Task<ActionResult<List<VmMemberInformation>>> GetAllMembers()
        {
            var memberList = await _db.MemberInformation
                                      .Select(x => new VmMemberInformation
                                      {
                                          NameInEnglish = x.NameInEnglish,
                                          NameInBangla = x.NameInBangla,
                                          DateOfBirth = x.DateOfBirth.ToString("dd MM yyyy"),
                                          NIDNumber = x.NIDNumber,
                                          Phone = x.Phone,
                                          Email = x.Email,
                                          Address = x.Address
                                      }).ToListAsync();
            return Json(memberList);
        }
    }
}
