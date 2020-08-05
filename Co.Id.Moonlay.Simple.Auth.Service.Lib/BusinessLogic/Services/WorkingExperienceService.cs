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
    public class WorkingExperienceService : IWorkingExperienceService
    {
        private const string UserAgent = "auth-service";
        protected DbSet<WorkingExperience> DbSet;
        protected IIdentityService IdentityService;
        public AuthDbContext DbContext;

        public WorkingExperienceService(IServiceProvider serviceProvider, AuthDbContext dbContext)
        {
            DbContext = dbContext;
            this.DbSet = dbContext.Set<WorkingExperience>();
            this.IdentityService = serviceProvider.GetService<IIdentityService>();
        }

        public bool CheckDuplicate(int id)
        {
            return DbSet.Any(r => r.IsDeleted.Equals(false) && r.Id != id);
        }

        public async Task<int> CreateAsync(WorkingExperience model)
        {
            EntityExtension.FlagForCreate(model, IdentityService.Username, UserAgent);
            DbSet.Add(model);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            WorkingExperience model = await ReadByIdAsync(id);
            EntityExtension.FlagForDelete(model, IdentityService.Username, UserAgent, true);
            DbSet.Update(model);
            return await DbContext.SaveChangesAsync();
        }

        public ReadResponse<WorkingExperience> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            IQueryable<WorkingExperience> query = DbSet.Where(x => !x.IsDeleted);
            List<string> searchAttributes = new List<string>()
            {
                "Company"
            };
            query = QueryHelper<WorkingExperience>.Search(query, searchAttributes, keyword);

            Dictionary<string, object> filterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(filter);
            query = QueryHelper<WorkingExperience>.Filter((IQueryable<WorkingExperience>)query, filterDictionary);

            List<string> selectedFields = new List<string>()
                {
                    "_id", "Company",
                };
            Dictionary<string, string> orderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(order);
            query = QueryHelper<WorkingExperience>.Order((IQueryable<WorkingExperience>)query, orderDictionary);

            query = query.Select(x => new WorkingExperience()
            {
                Id = x.Id,
                Company = x.Company,
                JobPositionExperience = x.JobPositionExperience,
                TanggalMulai = x.TanggalMulai,
                TanggalSelesai = x.TanggalSelesai,
                Deskripsi = x.Deskripsi,
                Sertifikat = x.Sertifikat
            });

            Pageable<WorkingExperience> pageable = new Pageable<WorkingExperience>(query, page - 1, size);
            List<WorkingExperience> data = pageable.Data.ToList();
            int totalData = pageable.TotalCount;

            return new ReadResponse<WorkingExperience>(data, totalData, orderDictionary, selectedFields);
        }

        public async Task<WorkingExperience> ReadByIdAsync(int id)
        {
            var result = await DbSet.FirstOrDefaultAsync(d => d.Id.Equals(id) && !d.IsDeleted);
            return result;
        }

        public async Task<int> UpdateAsync(int id, WorkingExperience model)
        {
            var data = await ReadByIdAsync(id);

            data.Company = model.Company;
            data.JobPositionExperience = model.JobPositionExperience;
            data.TanggalMulai = model.TanggalMulai;
            data.TanggalSelesai = model.TanggalSelesai;
            data.Deskripsi = model.Deskripsi;
            data.Sertifikat = model.Sertifikat;

            DbSet.Update(data);
            return await DbContext.SaveChangesAsync();
        }
    }
}
