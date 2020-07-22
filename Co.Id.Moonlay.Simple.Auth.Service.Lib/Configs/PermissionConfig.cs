using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Configs
{
    public class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(p => p.JobTitleName).HasMaxLength(255);
            builder.Property(p => p.JobTitleCode).HasMaxLength(255);
            builder.Property(p => p.JobStatus).HasMaxLength(225);
            builder.Property(p => p.UId).HasMaxLength(255);
            builder.Property(p => p.DivisionName).HasMaxLength(255);
        }
    }
}
