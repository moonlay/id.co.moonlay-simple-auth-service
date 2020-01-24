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
            builder.Property(p => p.Unit).HasMaxLength(255);
            builder.Property(p => p.UnitCode).HasMaxLength(255);
            builder.Property(p => p.UId).HasMaxLength(255);
            builder.Property(p => p.Division).HasMaxLength(255);
        }
    }
}
