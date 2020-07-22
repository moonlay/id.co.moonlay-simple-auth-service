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
    public class FamilyDataService : IFamilyDataService
    {
        private const string UserAgent = "auth-service";
        protected DbSet<FamilyData> DbSet;
        protected IIdentityService IdentityService;
        public AuthDbContext DbContext;

        public FamilyDataService(IServiceProvider serviceProvider, AuthDbContext dbContext)
        {
            DbContext = dbContext;
            this.DbSet = dbContext.Set<FamilyData>();
            this.IdentityService = serviceProvider.GetService<IIdentityService>();
        }

        public bool CheckDuplicate(int id, string ktpnumber)
        {
            return DbSet.Any(r => r.IsDeleted.Equals(false) && r.Id != id && r.KTPNumber.Equals(ktpnumber));
        }

        public async Task<int> CreateAsync(FamilyData model)
        {
            EntityExtension.FlagForCreate(model, IdentityService.Username, UserAgent);
            DbSet.Add(model);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            FamilyData model = await ReadByIdAsync(id);
            EntityExtension.FlagForDelete(model, IdentityService.Username, UserAgent, true);
            DbSet.Update(model);
            return await DbContext.SaveChangesAsync();
        }

        public ReadResponse<FamilyData> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            IQueryable<FamilyData> query = DbSet.Where(x => !x.IsDeleted);
            List<string> searchAttributes = new List<string>()
            {
                "KTPNumber"
            };
            query = QueryHelper<FamilyData>.Search(query, searchAttributes, keyword);

            Dictionary<string, object> filterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(filter);
            query = QueryHelper<FamilyData>.Filter((IQueryable<FamilyData>)query, filterDictionary);

            List<string> selectedFields = new List<string>()
                {
                    "_id", "FullNameOfFamily","KTPNumber",
                };
            Dictionary<string, string> orderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(order);
            query = QueryHelper<FamilyData>.Order((IQueryable<FamilyData>)query, orderDictionary);

            query = query.Select(x => new FamilyData()
            {
                Active = x.Active,
                CreatedAgent = x.CreatedAgent,
                CreatedBy = x.CreatedBy,
                CreatedUtc = x.CreatedUtc,
                DeletedAgent = x.DeletedAgent,
                DeletedBy = x.DeletedBy,
                DeletedUtc = x.DeletedUtc,
                Id = x.Id,
                IsDeleted = x.IsDeleted,
                LastModifiedAgent = x.LastModifiedAgent,
                LastModifiedBy = x.LastModifiedBy,
                LastModifiedUtc = x.LastModifiedUtc,
            });

            Pageable<FamilyData> pageable = new Pageable<FamilyData>(query, page - 1, size);
            List<FamilyData> data = pageable.Data.ToList();
            int totalData = pageable.TotalCount;

            return new ReadResponse<FamilyData>(data, totalData, orderDictionary, selectedFields);

        }

        public async Task<FamilyData> ReadByIdAsync(int id)
        {
            var result = await DbSet.FirstOrDefaultAsync(d => d.Id.Equals(id) && !d.IsDeleted);
            return result;
        }

        public async Task<int> UpdateAsync(int id, FamilyData model)
        {
            var data = await ReadByIdAsync(id);

            data.FullNameOfFamily = model.FullNameOfFamily;
            data.Relationship = model.Relationship;
            data.KTPNumber = model.KTPNumber;
            data.Gender = model.Gender;
            data.PhoneNumber = model.PhoneNumber;
            data.NameOfContact = model.NameOfContact;

            DbSet.Update(data);
            return await DbContext.SaveChangesAsync();
        }
    }
}
