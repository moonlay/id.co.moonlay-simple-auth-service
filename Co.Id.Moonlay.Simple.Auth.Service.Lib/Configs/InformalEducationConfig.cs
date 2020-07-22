using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Configs
{
    public class InformalEducationConfig : IEntityTypeConfiguration<InformalEducation>
    {
        public void Configure(EntityTypeBuilder<InformalEducation> builder)
        {
            builder.Property(p => p.HeldBy).HasMaxLength(255);
            builder.Property(p => p.Description).HasMaxLength(255);
        }
    }
}
