using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Configs
{
    public class AccountProfileConfig : IEntityTypeConfiguration<AccountProfile>
    {
        public void Configure(EntityTypeBuilder<AccountProfile> builder)
        {
            builder.Property(p => p.Fullname).HasMaxLength(255);
            builder.Property(p => p.EmployeeID).HasMaxLength(255);
            builder.Property(p => p.UId).HasMaxLength(255);
            builder.Property(p => p.Gender).HasMaxLength(6);
            builder.Property(p => p.Religion).HasMaxLength(15);
            builder.Property(p => p.Email).HasMaxLength(255);
            builder.Property(p => p.CoorporateEmail).HasMaxLength(225);
            builder.Property(p => p.Status).HasMaxLength(25);
            builder.Property(p => p.Password).HasMaxLength(25);
            builder.Property(p => p.SkillSet).HasMaxLength(255);
            builder.Property(p => p.FamilyData).HasMaxLength(255);
            builder.Property(p => p.EmergencyContact).HasMaxLength(255);
            builder.Property(p => p.EducationHistory).HasMaxLength(255);
            builder.Property(p => p.InfromalEducationHistory).HasMaxLength(255);
            builder.Property(p => p.WorkingEXP).HasMaxLength(255);
            builder.Property(p => p.JobTitleName).HasMaxLength(20);
            builder.Property(p => p.Department).HasMaxLength(20);

            //builder.HasKey(p => p.FamilyData);
        }
    }
}
