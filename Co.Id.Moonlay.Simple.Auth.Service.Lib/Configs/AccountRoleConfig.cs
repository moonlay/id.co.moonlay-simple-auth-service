using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Configs
{
    public class AccountRoleConfig : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> builder)
        {
            builder.Property(p => p.RoleUId).HasMaxLength(255);
            builder.Property(p => p.UId).HasMaxLength(255);
        }
    }
}
