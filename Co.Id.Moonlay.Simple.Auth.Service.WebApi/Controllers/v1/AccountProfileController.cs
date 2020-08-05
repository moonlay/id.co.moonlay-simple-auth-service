using AutoMapper;
using Co.Id.Moonlay.Simple.Auth.Service.Lib;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.AutoMapperProfiles;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Interfaces;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Services.IdentityService;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Services.ValidateService;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels.Forms;
using Co.Id.Moonlay.Simple.Auth.Service.WebApi.Utilities;
using Com.Moonlay.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AccountProfile = Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.AccountProfile;

namespace Co.Id.Moonlay.Simple.Auth.Service.WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/accountprofile")]
    [Authorize]
    public class AccountProfileController : Controller
    {
        private const string UserAgent = "auth-service";
        private readonly AuthDbContext _context;
        public static readonly string ApiVersion = "1.0.0";
        private readonly IIdentityService _identityService;
        private readonly IValidateService _validateService;

        public AccountProfileController(IIdentityService identityService, IValidateService validateService, AuthDbContext dbContext)
        {
            _identityService = identityService;
            _validateService = validateService;
            _context = dbContext;
        }

        protected void VerifyUser()
        {
            _identityService.Username = User.Claims.ToArray().SingleOrDefault(p => p.Type.Equals("username")).Value;
            _identityService.Token = Request.Headers["Authorization"].FirstOrDefault().Replace("Bearer ", "");
            _identityService.TimezoneOffset = Convert.ToInt32(Request.Headers["x-timezone-offset"]);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountProfile>>> GetAccountProfiles()
        {
            return await _context.AccountProfiles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountProfile>> GetAccountProfiles(long id)
        {
            var accountProfile = await _context.AccountProfiles.FindAsync(id);

            if (accountProfile == null)
            {
                return NotFound();
            }

            return accountProfile;
        }

        /*[HttpGet("exportXL")]
        public async Task<IActionResult> ExportAll()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            try
            {
                VerifyUser();
                var all = _TransportService.GetQuery().ToList();
                var total = all.Select(t => t.ApprovedExpense).Sum();
                var div = all
                    .GroupBy(d => d.Division)
                    .Select(t => new { Division = t.Key, Value = t.Sum(g => g.ReportedExpense) });



                var stream = new MemoryStream();



                using (var package = new ExcelPackage(stream))
                {
                    //sheet 1
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    //worksheet.Cells.LoadFromCollection(all, true);
                    int totalRows = all.Count();
                    worksheet.Cells[1, 1].Value = "Id";
                    worksheet.Cells[1, 2].Value = "Nama";
                    worksheet.Cells[1, 3].Value = "Divisi";
                    worksheet.Cells[1, 4].Value = "Receipt Date";
                    worksheet.Cells[1, 5].Value = "Description";
                    worksheet.Cells[1, 6].Value = "Departure Location";
                    worksheet.Cells[1, 7].Value = "Destination Location";
                    worksheet.Cells[1, 8].Value = "Approved Expense";
                    worksheet.Cells[1, 9].Value = "Total";
                    worksheet.Cells[1, 10].Value = "Divisi";



                    worksheet.Column(1).AutoFit();
                    worksheet.Column(2).AutoFit();
                    worksheet.Column(3).AutoFit();
                    worksheet.Column(4).AutoFit();
                    worksheet.Column(5).AutoFit();
                    worksheet.Column(6).AutoFit();
                    worksheet.Column(7).AutoFit();
                    worksheet.Column(8).AutoFit();
                    worksheet.Column(9).AutoFit();



                    int i = 0;
                    for (int row = 2; row <= totalRows + 1; row++)
                    {
                        worksheet.Cells[row, 1].Value = all[i].Id;
                        worksheet.Cells[row, 2].Value = all[i].Name;
                        worksheet.Cells[row, 3].Value = all[i].Division;
                        worksheet.Cells[row, 4].Value = all[i].ReceiptDate;
                        worksheet.Cells[row, 5].Value = all[i].Desc;
                        worksheet.Cells[row, 6].Value = all[i].DepartureLocation;
                        worksheet.Cells[row, 7].Value = all[i].DestinationLocation;
                        worksheet.Cells[row, 8].Value = all[i].ApprovedExpense;
                        worksheet.Cells[row, 9].Value = total;
                        worksheet.Cells[row, 10].Value = div;
                        i++;
                    }



                    package.Save();
                }
                stream.Position = 0;
                string excelName = $"Transport-{DateTime.Now.ToString("ddMMyyyy")}.xlsx";



                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }*/

        [HttpPost]
        public async Task<ActionResult<AccountProfile>> PostAccountProfile( [FromBody] AccountProfileFormViewModel accountProfile)
        {
            VerifyUser();
            var model = new AccountProfile()
            {
                Fullname = accountProfile.Fullname,
                EmployeeID = accountProfile.EmployeeId,
                Dob = accountProfile.DOB,
                Gender = accountProfile.Gender,
                Religion = accountProfile.Religion,
                Email = accountProfile.Email,
                Password = accountProfile.Password,
                JobTitleName = accountProfile.JobTitlename,
                Department = accountProfile.Departmanet,
                Status = accountProfile.Status,
                JoinDate = accountProfile.JoinDate,
                CoorporateEmail = accountProfile.CoorporateEmail,
                SkillSet = accountProfile.SkillSet,
            };
            EntityExtension.FlagForCreate(model, _identityService.Username, UserAgent);
            _context.AccountProfiles.Add(model);

            var assetmodel = new Asset()
            {
                AssetName = accountProfile.AssetName,
                AssetNumber = accountProfile.AssetNumber
            };
            EntityExtension.FlagForCreate(assetmodel, _identityService.Username, UserAgent);
            _context.Assets.Add(assetmodel);

            var payrollmodel = new Payroll()
            {
                Salary = accountProfile.Salary,
                Tax = accountProfile.Tax,
                BPJSKesehatan = accountProfile.BPJSKesehatan,
                BPJSTenagaKerja = accountProfile.BPJSTenagakerja,
                NPWP = accountProfile.NPWP,
                NameBankAccount = accountProfile.NameBankAccount,
                Bank = accountProfile.Bank,
                BankAccountNumber = accountProfile.BankAccountNumber,
                BankBranch = accountProfile.BankBranch
            };
            EntityExtension.FlagForCreate(payrollmodel, _identityService.Username, UserAgent);
            _context.Payrolls.Add(payrollmodel);

            await _context.SaveChangesAsync();
            return Created("", model);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountProfile(long id, [FromBody] PersonalDataFormViewModel accountProfile)
        {
            /*if (id != accountProfile.Id)
            {
                return BadRequest();
            }*/

            try
            {
                VerifyUser();
                var model = await _context.AccountProfiles.FindAsync(id);
                {
                    model.EmployeeID = accountProfile.EmployeeId;
                    model.Fullname = accountProfile.Fullname;
                    model.Dob = accountProfile.DOB;
                    model.Gender = accountProfile.Gender;
                    model.Religion = accountProfile.Religion;
                    model.Email = accountProfile.Email;
                    model.EmployeePhoneNumber = accountProfile.EmployeePhoneNumber;
                };
                EntityExtension.FlagForUpdate(model, _identityService.Username, UserAgent);
                _context.AccountProfiles.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!accountProfileExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool accountProfileExist(long id)
        {
            return _context.AccountProfiles.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountProfile>> DeleteAccountProfile(int id)
        {
            VerifyUser();
            var accountProfile = await _context.AccountProfiles.FindAsync(id);
            if (accountProfile == null)
            {
                return NotFound();
            }

            _context.AccountProfiles.Remove(accountProfile);
            await _context.SaveChangesAsync();

            return accountProfile;
        }
    }
}
