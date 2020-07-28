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
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Co.Id.Moonlay.Simple.Auth.Service.WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/informaleducation")]
    [Authorize]

    public class InformalEducationController : Controller
    {
        private const string UserAgent = "auth-service";
        private readonly AuthDbContext _context;
        public static readonly string ApiVersion = "1.0.0";
        private readonly IIdentityService _identityService;
        private readonly IValidateService _validateService;

        public InformalEducationController(IIdentityService identityService, IValidateService validateService, AuthDbContext dbContext)
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
        public async Task<ActionResult<IEnumerable<InformalEducation>>> GetInformalEducations()
        {
            return await _context.InformalEducations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InformalEducation>> GetinformalEducations(int id)
        {
            VerifyUser();
            var informalEducation = await _context.InformalEducations.FindAsync(id);

            if (informalEducation == null)
            {
                return NotFound();
            }

            return informalEducation;
        }

        [HttpPost]
        public async Task<ActionResult<InformalEducation>> PostinformalEducation([FromBody] InformalEducationFormViewModel informalEducation)
        {
            VerifyUser();
            var model = new InformalEducation()
            {
                Certificate = informalEducation.Certificate.GetValueOrDefault(),
                Description = informalEducation.Description,
                JobPosition = informalEducation.JobPosition,
                EndDate = informalEducation.EndDate,
                HeldBy = informalEducation.HeldBy,
                StartDate = informalEducation.StartDate
            };
            EntityExtension.FlagForCreate(model, _identityService.Username, UserAgent);
            _context.InformalEducations.Add(model);
            await _context.SaveChangesAsync();
            return Created("", model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<InformalEducation>> DeleteInformalEducation(int id)
        {
            VerifyUser();
            var informalEducation = await _context.InformalEducations.FindAsync(id);
            if (informalEducation == null)
            {
                return NotFound();
            }
            _context.InformalEducations.Remove(informalEducation);
            await _context.SaveChangesAsync();

            return informalEducation;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInformalEducation(int id, [FromBody] InformalEducationFormViewModel informalEducation)
        {
            /*if (id != informalEducation.Id)
            {
                return BadRequest();
            }*/

            try
            {
                VerifyUser();
                var model = await _context.InformalEducations.FindAsync(id);
                {
                    model.Description = informalEducation.Description;
                    model.JobPosition = informalEducation.JobPosition;
                    model.EndDate = informalEducation.EndDate;
                    model.HeldBy = informalEducation.HeldBy;
                    model.StartDate = informalEducation.StartDate;
                };
                EntityExtension.FlagForUpdate(model, _identityService.Username, UserAgent);
                _context.InformalEducations.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!informalEducationExist(id))
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

        private bool informalEducationExist(int id)
        {
            return _context.InformalEducations.Any(e => e.Id == id);
        }
    }
}
