using Co.Id.Moonlay.Simple.Auth.Service.Lib.Configs;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Com.Moonlay.Data.EntityFrameworkCore;
using Com.Moonlay.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib
{
    public class AuthDbContext : StandardDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountProfile> AccountProfiles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<FamilyData>FamilyDatas { get; set; }
        public DbSet<EducationInfo>EducationInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Account>(new AccountConfig());
            modelBuilder.ApplyConfiguration<AccountProfile>(new AccountProfileConfig());
            modelBuilder.ApplyConfiguration<Permission>(new PermissionConfig());
            modelBuilder.ApplyConfiguration<Role>(new RoleConfig());
            modelBuilder.ApplyConfiguration<AccountRole>(new AccountRoleConfig());
            modelBuilder.ApplyConfiguration<Asset>(new AssetConfig());
            modelBuilder.ApplyConfiguration<Payroll>(new PayrollConfig());
            modelBuilder.ApplyConfiguration<FamilyData>(new FamilyDataConfig());
            modelBuilder.ApplyConfiguration<EducationInfo>(new EducationInfoConfig());
        }
    }
}
