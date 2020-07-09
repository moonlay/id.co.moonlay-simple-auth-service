using Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Interfaces;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Services.IdentityService;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Utilities;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels;
using Com.Moonlay.Models;
using Com.Moonlay.NetCore.Lib;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Services
{
    public class AccountProfileService : IAccountProfileService
    {
        protected DbSet<AccountProfile> DbSet;
        protected IIdentityService IdentityService;
        public AuthDbContext DbContext;

        public AccountProfileService(IServiceProvider serviceProvider, AuthDbContext dbContext)
        {
            DbContext = dbContext;
            this.DbSet = dbContext.Set<AccountProfile>();
        }

        public bool CheckDuplicate(int id, string fullname, string email)
        {
            return DbSet.Any(r => r.IsDeleted.Equals(false) && r.Id != id && r.Fullname.Equals(fullname)
            && r.Email.Equals(email));
        }

        public Task<int> CreateAsync(AccountProfile model)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountProfile>> GetAccountProfileByFullName(string fullname)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountProfile>> GetAccountProfilesByReligion(string religion)
        {
            throw new NotImplementedException();
        }

        public ReadResponse<AccountProfile> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            IQueryable<AccountProfile> query = DbSet.Where(x => !x.IsDeleted);

            List<string> searchAttributes = new List<string>()
            {
                "Fullname"
            };

            query = QueryHelper<Account>.Search(query, searchAttributes, keyword);

            Dictionary<string, object> filterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(filter);
            query = QueryHelper<AccountProfile>.Filter((IQueryable<AccountProfile>)query, filterDictionary);

            List<string> selectedFields = new List<string>()
                {
                    "_id", "FullName","EmployeeID",
                };

            Dictionary<string, string> orderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(order);
            query = QueryHelper<AccountProfile>.Order((IQueryable<AccountProfile>)query, orderDictionary);

            query = query.Select(x => new AccountProfile()
            {
                Family = x.Family,
                EducationInfo = x.EducationInfo,
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

            Pageable<AccountProfile> pageable = new Pageable<AccountProfile>(query, page - 1, size);
            List<AccountProfile> data = pageable.Data.ToList();
            int totalData = pageable.TotalCount;

            return new ReadResponse<AccountProfile>(data, totalData, orderDictionary, selectedFields);
        }

        public async Task<AccountProfile> ReadByIdAsync(int id)
        {
            var result = await DbSet
                .Include(x => x.Family)
                .Include(x => x.EducationInfo)
                .FirstOrDefaultAsync(d => d.Id.Equals(id) && !d.IsDeleted);
            return result;
        }

        public Task<int> UpdateAsync(int id, AccountProfile model)
        {
            throw new NotImplementedException();
        }
    }
}
