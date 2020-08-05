using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Configs
{
    public class WorkingExperienceConfig : IEntityTypeConfiguration<WorkingExperience>
    {
        public void Configure(EntityTypeBuilder<WorkingExperience> builder)
        {
            builder.Property(p => p.Company).HasMaxLength(255);
            builder.Property(p => p.JobPositionExperience).HasMaxLength(255);
            builder.Property(p => p.Deskripsi).HasMaxLength(255);
        }
    }
}
