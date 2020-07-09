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
    [Route("v{version:apiVersion}/accountprofile")]
    [Authorize]
    public class FamilyDataController : Controller
    {
        private readonly AuthDbContext _context;
        public static readonly string ApiVersion = "1.0.0";

        public FamilyDataController(AuthDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyData>>> GetFamilyDatas()
        {
            return await _context.FamilyDatas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyData>> GetFamilyDatas(long id)
        {
            var familyData = await _context.FamilyDatas.FindAsync(id);

            if (familyData == null)
            {
                return NotFound();
            }

            return familyData;
        }

        [HttpPost]
        public async Task<ActionResult<FamilyData>> PostFamilyData(FamilyData familyData)
        {
            _context.FamilyDatas.Add(familyData);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(FamilyData), new { id = familyData.Id }, familyData);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FamilyData>> DeleteFamilyData(long id)
        {
            var familyData = await _context.FamilyDatas.FindAsync(id);
            if (familyData == null)
            {
                return NotFound();
            }

            _context.FamilyDatas.Remove(familyData);
            await _context.SaveChangesAsync();

            return familyData;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamilyData(long id, FamilyData familyData)
        {
            if (id != familyData.Id)
            {
                return BadRequest();
            }

            _context.Entry(familyData).State = EntityState.Modified;

            try
            {
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
            return _context.FamilyDatas.Any(e => e.Id == id);
        }
    }
}
