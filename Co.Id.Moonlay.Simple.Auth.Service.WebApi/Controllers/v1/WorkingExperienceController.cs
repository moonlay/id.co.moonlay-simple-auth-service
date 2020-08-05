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

namespace Co.Id.Moonlay.Simple.Auth.Service.WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/workingExperience")]
    [Authorize]

    public class WorkingExperienceController : Controller
    {
        private const string UserAgent = "auth-service";
        private readonly AuthDbContext _context;
        public static readonly string ApiVersion = "1.0.0";
        private readonly IIdentityService _identityService;
        private readonly IValidateService _validateService;

        public WorkingExperienceController(IIdentityService identityService, IValidateService validateService, AuthDbContext dbContext)
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
        public async Task<ActionResult<IEnumerable<WorkingExperience>>> GetWorkingExperiences()
        {
            return await _context.WorkingExperiences.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkingExperience>> GetWorkingExperiences(int id)
        {
            var workingExperience = await _context.WorkingExperiences.FindAsync(id);

            if (workingExperience == null)
            {
                return NotFound();
            }

            return workingExperience;
        }

        [HttpPost]
        public async Task<ActionResult<WorkingExperience>> PostWorkingExperience( [FromBody] WorkingExperienceFormViewModel workingExperience)
        {
            VerifyUser();
            var model = new WorkingExperience()
            {
                Company = workingExperience.Company,
                JobPositionExperience = workingExperience.JobPositionExperience,
                TanggalMulai = workingExperience.TanggalMulai,
                TanggalSelesai = workingExperience.TanggalSelesai,
                Deskripsi = workingExperience.Deskripsi,
                Sertifikat = workingExperience.Sertifikat.GetValueOrDefault()

            };
            EntityExtension.FlagForCreate(model, _identityService.Username, UserAgent);
            _context.WorkingExperiences.Add(model);
            await _context.SaveChangesAsync();
            return Created("", model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkingExperience>> DeleteWorkingExperience(int id)
        {
            VerifyUser();
            var workingExperience = await _context.WorkingExperiences.FindAsync(id);
            if (workingExperience == null)
            {
                return NotFound();
            }

            _context.WorkingExperiences.Remove(workingExperience);
            await _context.SaveChangesAsync();

            return workingExperience;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkingExperience(int id, [FromBody] WorkingExperienceFormViewModel workingExperience)
        {
            /*if (id != workingExperience.Id)
            {
                return BadRequest();
            }*/

            try
            {
                VerifyUser();
                var model = await _context.WorkingExperiences.FindAsync(id);
                {
                    model.Company = workingExperience.Company;
                    model.JobPositionExperience = workingExperience.JobPositionExperience;
                    model.TanggalMulai = workingExperience.TanggalMulai;
                    model.TanggalSelesai = workingExperience.TanggalSelesai;
                    model.Deskripsi = workingExperience.Deskripsi;
                };
                EntityExtension.FlagForUpdate(model, _identityService.Username, UserAgent);
                _context.WorkingExperiences.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkingExperienceExist(id))
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

        private bool WorkingExperienceExist(long id)
        {
            return _context.WorkingExperiences.Any(e => e.Id == id);
        }
    }
}
