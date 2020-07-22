using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Com.Moonlay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Configs
{
    public class EducationInfoConfig : IEntityTypeConfiguration<EducationInfo>
    {
        public void Configure(EntityTypeBuilder<EducationInfo> builder)
        {
            builder.Property(p => p.Grade).HasMaxLength(25);
            builder.Property(p => p.Institution).HasMaxLength(225);
            builder.Property(p => p.Majors).HasMaxLength(255);
        }
    }
}
