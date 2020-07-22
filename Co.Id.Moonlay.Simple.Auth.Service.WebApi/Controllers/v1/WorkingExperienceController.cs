using AutoMapper;
using Co.Id.Moonlay.Simple.Auth.Service.Lib;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.AutoMapperProfiles;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Interfaces;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Services.IdentityService;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Services.ValidateService;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels;
using Co.Id.Moonlay.Simple.Auth.Service.WebApi.Utilities;
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
        private readonly AuthDbContext _context;
        public static readonly string ApiVersion = "1.0.0";

        public WorkingExperienceController(AuthDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkingExperience>>> GetWorkingExperiences()
        {
            return await _context.WorkingExperiences.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkingExperience>> GetWorkingExperiences(long id)
        {
            var workingExperience = await _context.WorkingExperiences.FindAsync(id);

            if (workingExperience == null)
            {
                return NotFound();
            }

            return workingExperience;
        }

        [HttpPost]
        public async Task<ActionResult<WorkingExperience>> PostWorkingExperience(WorkingExperience workingExperience)
        {
            _context.WorkingExperiences.Add(workingExperience);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(WorkingExperience), new { id = workingExperience.Id }, workingExperience);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkingExperience>> DeleteWorkingExperience(long id)
        {
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
        public async Task<IActionResult> PutWorkingExperience(long id, WorkingExperience workingExperience)
        {
            if (id != workingExperience.Id)
            {
                return BadRequest();
            }

            _context.Entry(workingExperience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!workingExperienceExist(id))
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

        private bool workingExperienceExist(long id)
        {
            return _context.WorkingExperiences.Any(e => e.Id == id);
        }
    }
}
