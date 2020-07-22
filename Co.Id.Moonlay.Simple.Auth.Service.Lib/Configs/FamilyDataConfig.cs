using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Configs
{
    public class FamilyDataConfig : IEntityTypeConfiguration<FamilyData>
    {
        public void Configure(EntityTypeBuilder<FamilyData> builder)
        {
            builder.Property(p => p.FullNameOfFamily).HasMaxLength(255);
            builder.Property(p => p.Relationship).HasMaxLength(20);
            builder.Property(p => p.Religion).HasMaxLength(15);
            builder.Property(p => p.Gender).HasMaxLength(10);
            builder.Property(p => p.KTPNumber).HasMaxLength(255);
            builder.Property(p => p.NameOfContact).HasMaxLength(255);
            builder.Property(p => p.PhoneNumber).HasMaxLength(255);
        }
    }
}
