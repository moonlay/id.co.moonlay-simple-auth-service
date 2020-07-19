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
using AccountProfile = Co.Id.Moonlay.Simple.Auth.Service.Lib.Models.AccountProfile;

namespace Co.Id.Moonlay.Simple.Auth.Service.WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/accountprofile")]
    [Authorize]
    public class AccountProfileController : Controller
    {
        private readonly AuthDbContext _context;
        private readonly IAccountProfileService _accountProfileService;
        private readonly IMapper _mapper;
        public static readonly string ApiVersion = "2.0.0";

        public AccountProfileController(AuthDbContext context, IAccountProfileService accountProfileService, IMapper mapper)
        {
            _context = context;
            _accountProfileService = accountProfileService;
            _mapper = mapper;
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
        public async Task<ActionResult<AccountProfile>> PostAccountProfile(AccountProfile accountProfile, AccountProfileViewModel model)
        {
            var profile = _mapper.Map<AccountProfileViewModel, AccountProfile>(model);
            _context.AccountProfiles.Add(accountProfile);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(AccountProfile), new { id = accountProfile.Id }, accountProfile);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountProfile(long id, AccountProfile accountProfile)
        {
            if (id != accountProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(accountProfile).State = EntityState.Modified;

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
            return _context.AccountProfiles.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountProfile>> DeleteAccountProfile(long id)
        {
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
