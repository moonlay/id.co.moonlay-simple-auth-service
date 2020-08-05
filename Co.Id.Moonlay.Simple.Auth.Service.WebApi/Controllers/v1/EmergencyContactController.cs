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
    [Route("v{version:apiVersion}/familydata/emergencyContact")]
    [Authorize]
    public class EmergencyContactController : Controller
    {
        private const string UserAgent = "auth-service";
        private readonly AuthDbContext _context;
        public static readonly string ApiVersion = "1.0.0";
        private readonly IIdentityService _identityService;
        private readonly IValidateService _validateService;
        public EmergencyContactController(IIdentityService identityService, IValidateService validateService, AuthDbContext dbContext)
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
        public async Task<ActionResult<IEnumerable<EmergencyContact>>> GetEmergencyContact()
        {
            return await _context.EmergencyContacts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmergencyContact>> GetEmegencyContactById(int id)
        {
            var emergencyContact = await _context.EmergencyContacts.FindAsync(id);

            if (emergencyContact == null)
            {
                return NotFound();
            }

            return emergencyContact;
        }

        [HttpPost]
        public async Task<ActionResult<EmergencyContact>> PostEmergencyContact([FromBody] EmergencyContactFormViewModel emergencyContact)
        {
            VerifyUser();
            var model = new EmergencyContact()
            {
                NameOfContact = emergencyContact.NameOfContact,
                Relationship = emergencyContact.Relationship,
                PhoneNumber = emergencyContact.PhoneNumber
            };
            EntityExtension.FlagForCreate(model, _identityService.Username, UserAgent);
            _context.EmergencyContacts.Add(model);
            await _context.SaveChangesAsync();
            return Created("", model);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmergencyContact>> DeleteEmergencyContact(int id)
        {
            VerifyUser();
            var emergencyContact = await _context.EmergencyContacts.FindAsync(id);
            if (emergencyContact == null)
            {
                return NotFound();
            }

            _context.EmergencyContacts.Remove(emergencyContact);
            await _context.SaveChangesAsync();

            return emergencyContact;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmergencyCintact(int id, [FromBody] EmergencyContactFormViewModel emergencyContact)
        {
            /*if (id != emergency.Id)
            {
                return BadRequest();
            }*/

            try
            {
                VerifyUser();
                var model = await _context.EmergencyContacts.FindAsync(id);
                {
                    model.NameOfContact = emergencyContact.NameOfContact;
                    model.Relationship = emergencyContact.Relationship;
                    model.PhoneNumber = emergencyContact.PhoneNumber;
                };
                EntityExtension.FlagForUpdate(model, _identityService.Username, UserAgent);
                _context.EmergencyContacts.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmergencyContactExist(id))
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

        private bool EmergencyContactExist(long id)
        {
            throw new NotImplementedException();
        }
    }
}
