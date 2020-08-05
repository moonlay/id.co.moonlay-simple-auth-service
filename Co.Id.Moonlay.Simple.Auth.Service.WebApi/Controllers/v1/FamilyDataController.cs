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
    [Route("v{version:apiVersion}/familydata")]
    [Authorize]
    public class FamilyDataController : Controller
    {
        private const string UserAgent = "auth-service";
        private readonly AuthDbContext _context;
        public static readonly string ApiVersion = "1.0.0";
        private readonly IIdentityService _identityService;
        private readonly IValidateService _validateService;

        public FamilyDataController(IIdentityService identityService, IValidateService validateService, AuthDbContext dbContext)
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
        public async Task<ActionResult<IEnumerable<FamilyData>>> GetFamilyDatas()
        {
            return await _context.FamilyDatas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyData>> GetFamilyDatas(int id)
        {
            var familyData = await _context.FamilyDatas.FindAsync(id);

            if (familyData == null)
            {
                return NotFound();
            }

            return familyData;
        }

        [HttpPost]
        public async Task<ActionResult<FamilyData>> PostFamilyData( [FromBody] FamilyDataFormViewModel familyData)
        {
            VerifyUser();
            var model = new FamilyData()
            {
                FullNameOfFamily = familyData.FullNameOfFamily,
                Relationship = familyData.Relationship,
                DOBFamily = familyData.DOBFamily,
                Religion = familyData.Religion,
                Gender = familyData.Gender,
                KTPNumber = familyData.KTPNumber
            };
            EntityExtension.FlagForCreate(model, _identityService.Username, UserAgent);
            _context.FamilyDatas.Add(model);
            await _context.SaveChangesAsync();
            return Created("", model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FamilyData>> DeleteFamilyData(int id)
        {
            VerifyUser();
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
        public async Task<IActionResult> PutFamilyData(int id, [FromBody] FamilyDataFormViewModel familyData)
        {
            /*if (id != familyData.Id)
            {
                return BadRequest();
            }*/

            try
            {
                VerifyUser();
                var model = await _context.FamilyDatas.FindAsync(id);
                {
                    model.FullNameOfFamily = familyData.FullNameOfFamily;
                    model.Relationship = familyData.Relationship;
                    model.DOBFamily = familyData.DOBFamily;
                    model.Gender = familyData.Gender;
                    model.Religion = familyData.Religion;
                    model.KTPNumber = familyData.KTPNumber;
                };
                EntityExtension.FlagForUpdate(model, _identityService.Username, UserAgent);
                _context.FamilyDatas.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountProfileExist(id))
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

        private bool AccountProfileExist(long id)
        {
            return _context.FamilyDatas.Any(e => e.Id == id);
        }
    }
}
