using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Configs
{
    public class EmergencyContactConfig : IEntityTypeConfiguration<EmergencyContact>
    {
        public void Configure(EntityTypeBuilder<EmergencyContact> builder)
        {
            builder.Property(p => p.NameOfContact).HasMaxLength(225);
            builder.Property(p => p.Relationship).HasMaxLength(25);
            builder.Property(p => p.PhoneNumber).HasMaxLength(20);
        }
    }
}
