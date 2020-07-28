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
                SkillSet = accountProfile.SkillSet
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
