using Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Interfaces;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Services.IdentityService;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Utilities;
using Com.Moonlay.Models;
using Com.Moonlay.NetCore.Lib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Services
{
    public class EmergencyContactService : IEmergencyContactService
    {
        private const string UserAgent = "auth-service";
        protected DbSet<EmergencyContact> DbSet;
        protected IIdentityService IdentityService;
        public AuthDbContext DbContext;
        
        public EmergencyContactService(IServiceProvider serviceProvider, AuthDbContext dbContext)
        {
            DbContext = dbContext;
            this.DbSet = dbContext.Set<EmergencyContact>();
            this.IdentityService = serviceProvider.GetService<IIdentityService>();
        }

        public bool CheckDuplicate(int id)
        {
            return DbSet.Any(r => r.IsDeleted.Equals(false) && r.Id != id);
        }

        public async Task<int> CreateAsync(EmergencyContact model)
        {
            EntityExtension.FlagForCreate(model, IdentityService.Username, UserAgent);
            DbSet.Add(model);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            EmergencyContact model = await ReadByIdAsync(id);
            EntityExtension.FlagForDelete(model, IdentityService.Username, UserAgent, true);
            DbSet.Update(model);
            return await DbContext.SaveChangesAsync();
        }

        public ReadResponse<EmergencyContact> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            IQueryable<EmergencyContact> query = DbSet.Where(x => !x.IsDeleted);
            List<string> searchAttributes = new List<string>()
            {
                "NameOfContact"
            };
            query = QueryHelper<EmergencyContact>.Search(query, searchAttributes, keyword);

            Dictionary<string, object> filterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(filter);
            query = QueryHelper<EmergencyContact>.Filter((IQueryable<EmergencyContact>)query, filterDictionary);

            List<string> selectedFields = new List<string>()
                {
                    "_id",
                };
            Dictionary<string, string> orderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(order);
            query = QueryHelper<EmergencyContact>.Order((IQueryable<EmergencyContact>)query, orderDictionary);

            query = query.Select(x => new EmergencyContact()
            {
                Id = x.Id,
                NameOfContact = x.NameOfContact,
                Relationship = x.Relationship,
                PhoneNumber = x.PhoneNumber
            });

            Pageable<EmergencyContact> pageable = new Pageable<EmergencyContact>(query, page - 1, size);
            List<EmergencyContact> data = pageable.Data.ToList();
            int totalData = pageable.TotalCount;

            return new ReadResponse<EmergencyContact>(data, totalData, orderDictionary, selectedFields);
        }

        public async Task<EmergencyContact> ReadByIdAsync(int id)
        {
            var result = await DbSet.FirstOrDefaultAsync(d => d.Id.Equals(id) && !d.IsDeleted);
            return result;
        }

        public async Task<int> UpdateAsync(int id, EmergencyContact model)
        {
            var data = await ReadByIdAsync(id);

            data.NameOfContact = model.NameOfContact;
            data.Relationship = model.Relationship;
            data.PhoneNumber = model.PhoneNumber;

            DbSet.Update(data);
            return await DbContext.SaveChangesAsync();
        }
    }
}
