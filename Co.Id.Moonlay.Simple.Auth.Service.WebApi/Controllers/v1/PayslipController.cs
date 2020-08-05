using Co.Id.Moonlay.Simple.Auth.Service.Lib;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Services.IdentityService;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Services.ValidateService;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels.Forms;
using Com.Moonlay.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Co.Id.Moonlay.Simple.Auth.Service.WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/payroll/payslip")]
    [Authorize]
    public class PayslipController : Controller
    {
        private const string UserAgent = "auth-service";
        private readonly AuthDbContext _context;
        public static readonly string ApiVersion = "1.0.0";
        private readonly IIdentityService _identityService;
        private readonly IValidateService _validateService;

        public PayslipController(IIdentityService identityService, IValidateService validateService, AuthDbContext dbContext)
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
        public async Task<ActionResult<IEnumerable<Payroll>>> GetPayslips()
        {
            return await _context.Payrolls.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payroll>> GetPayslips(int id)
        {
            var payslip = await _context.Payrolls.FindAsync(id);

            if (payslip == null)
            {
                return NotFound();
            }

            return payslip;
        }

        [HttpPost]
        public async Task<ActionResult<Payroll>> PostPayslips([FromBody] PayslipFormViewModel payslip)
        {
            VerifyUser();
            var model = new Payroll()
            {
                SalaryPeriod = payslip.SalaryPeriod,
                Bank = payslip.Bank,
                BankAccountNumber = payslip.BankAccountNumber,
                Salary = payslip.Salary,
                BackDatedPayment = payslip.BackDatedPayment,
                Allowance = payslip.Allowance,
                Incentive = payslip.Incentive,
                PaidLeave = payslip.PaidLeave,
                BPJSKesehatan = payslip.BPJSKesehatan,
                BPJSTenagaKerja = payslip.BPJSTenagaKerja,
            };
            EntityExtension.FlagForCreate(model, _identityService.Username, UserAgent);
            _context.Payrolls.Add(model);
            await _context.SaveChangesAsync();
            return Created("", model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Payroll>> DeletePayslip(int id)
        {
            VerifyUser();
            var payslip = await _context.Payrolls.FindAsync(id);
            if (payslip == null)
            {
                return NotFound();
            }

            _context.Payrolls.Remove(payslip);
            await _context.SaveChangesAsync();

            return payslip;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayslips(int id, [FromBody] PayslipFormViewModel payslip)
        {
            /*if (id != familyData.Id)
            {
                return BadRequest();
            }*/

            try
            {
                VerifyUser();
                var model = await _context.Payrolls.FindAsync(id);
                {
                    model.SalaryPeriod = payslip.SalaryPeriod;
                    model.Bank = payslip.Bank;
                    model.BankAccountNumber = payslip.BankAccountNumber;
                    model.Salary = payslip.Salary;
                    model.BackDatedPayment = payslip.BackDatedPayment;
                    model.Allowance = payslip.Allowance;
                    model.Incentive = payslip.Incentive;
                    model.PaidLeave = payslip.PaidLeave;
                    model.BPJSKesehatan = payslip.BPJSKesehatan;
                    model.BPJSTenagaKerja = payslip.BPJSTenagaKerja;
                };
                EntityExtension.FlagForUpdate(model, _identityService.Username, UserAgent);
                _context.Payrolls.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayrollsExist(id))
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

        private bool PayrollsExist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
