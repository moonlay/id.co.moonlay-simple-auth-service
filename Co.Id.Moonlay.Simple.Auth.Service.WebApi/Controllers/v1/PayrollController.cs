using Co.Id.Moonlay.Simple.Auth.Service.Lib;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Services.IdentityService;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Services.ValidateService;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels.Forms;
using Com.Moonlay.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses.ResultOperators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Co.Id.Moonlay.Simple.Auth.Service.WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/payroll")]
    [Authorize]
    public class PayrollController : Controller
    {
        private const string UserAgent = "auth-service";
        private readonly AuthDbContext _context;
        public static readonly string ApiVersion = "1.0.0";
        private readonly IIdentityService _identityService;
        private readonly IValidateService _validateService;

        public PayrollController(IIdentityService identityService, IValidateService validateService, AuthDbContext dbContext)
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
        public async Task<ActionResult<IEnumerable<Payroll>>> GetPayrolls()
        {
            return await _context.Payrolls.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payroll>> GetPayrollsById(int id)
        {
            var payroll = await _context.Payrolls.FindAsync(id);

            if (payroll == null)
            {
                return NotFound();
            }

            return payroll;
        }

        [HttpPost]
        public async Task<ActionResult<Payroll>> PostPayrolls([FromBody] PayrollFormViewModel payroll)
        {
            VerifyUser();
            var model = new Payroll()
            {
                Salary = payroll.Salary,
                Tax = payroll.Tax,
                BPJSKesehatan = payroll.BPJSKesehatan,
                BPJSTenagaKerja = payroll.BPJSTenagaKerja,
                NPWP = payroll.NPWP,
                NameBankAccount = payroll.NameBankAccount,
                Bank = payroll.Bank,
                BankAccountNumber = payroll.BankAccountNumber,
                BankBranch = payroll.BankBranch,
                BackDatedPayment = payroll.BackDatedPayment,
                Allowance = payroll.Allowance,
                Incentive = payroll.Incentive,
                PaidLeave = payroll.PaidLeave,
                UnPaidLeave = payroll.UnPaidLeave,
                SalaryPeriod = payroll.SalaryPeriod,
                Month = payroll.Month,
                Year = payroll.Year,
                TakeHomePay = payroll.TakeHomePay
            };
            EntityExtension.FlagForCreate(model, _identityService.Username, UserAgent);
            _context.Payrolls.Add(model);
            await _context.SaveChangesAsync();
            return Created("", model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Payroll>> DeletePayrolls(int id)
        {
            VerifyUser();
            var payroll = await _context.Payrolls.FindAsync(id);
            if (payroll == null)
            {
                return NotFound();
            }

            _context.Payrolls.Remove(payroll);
            await _context.SaveChangesAsync();

            return payroll;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayrolls(int id, [FromBody] PayrollFormViewModel payroll)
        {
            /*if (id != workingExperience.Id)
            {
                return BadRequest();
            }*/

            try
            {
                VerifyUser();
                var model = await _context.Payrolls.FindAsync(id);
                {
                    model.Salary = payroll.Salary;
                    model.Tax = payroll.Tax;
                    model.BPJSKesehatan = payroll.BPJSKesehatan;
                    model.BPJSTenagaKerja = payroll.BPJSTenagaKerja;
                    model.NPWP = payroll.NPWP;
                    model.NameBankAccount = payroll.NameBankAccount;
                    model.Bank = payroll.Bank;
                    model.BankAccountNumber = payroll.BankAccountNumber;
                    model.BankBranch = payroll.BankBranch;
                    model.BackDatedPayment = payroll.BackDatedPayment;
                    model.Allowance = payroll.Allowance;
                    model.Incentive = payroll.Incentive;
                    model.PaidLeave = payroll.PaidLeave;
                    model.UnPaidLeave = payroll.UnPaidLeave;
                    model.SalaryPeriod = payroll.SalaryPeriod;
                    model.Month = payroll.Month;
                    model.Year = payroll.Year;
                    model.TakeHomePay = payroll.TakeHomePay;
                };
                EntityExtension.FlagForUpdate(model, _identityService.Username, UserAgent);
                _context.Payrolls.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayrollExist(id))
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

        private bool PayrollExist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
