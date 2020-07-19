using Co.Id.Moonlay.Simple.Auth.Service.Lib;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
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
    [Route("v{version:apiVersion}/educationinfo")]
    [Authorize]
    public class EducationInfoController : Controller
    {
        private readonly AuthDbContext _context;
        public static readonly string ApiVersion = "1.0.0";

        public EducationInfoController(AuthDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationInfo>>> GetEducationInfos()
        {
            return await _context.EducationInfos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EducationInfo>> GetEducationInfos(long id)
        {
            var educationInfo = await _context.EducationInfos.FindAsync(id);

            if (educationInfo == null)
            {
                return NotFound();
            }

            return educationInfo;
        }

        [HttpPost]
        public async Task<ActionResult<EducationInfo>> PostEducationInfo(EducationInfo educationInfo)
        {
            _context.EducationInfos.Add(educationInfo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(EducationInfo), new { id = educationInfo.Id }, educationInfo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EducationInfo>> DeleteEducationInfo(long id)
        {
            var educationInfo = await _context.EducationInfos.FindAsync(id);
            if (educationInfo == null)
            {
                return NotFound();
            }

            _context.EducationInfos.Remove(educationInfo);
            await _context.SaveChangesAsync();

            return educationInfo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationInfo(long id, EducationInfo educationInfo)
        {
            if (id != educationInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(educationInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!educationInfoExist(id))
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

        private bool educationInfoExist(long id)
        {
            return _context.EducationInfos.Any(e => e.Id == id);
        }
    }
}
