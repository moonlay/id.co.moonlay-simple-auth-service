using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Configs
{
    class PayrollConfig : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> builder)
        {
            builder.Property(p => p.Salary).HasMaxLength(255);
            builder.Property(p => p.Tax).HasMaxLength(255);
            builder.Property(p => p.BPJSKesehatan).HasMaxLength(255);
            builder.Property(p => p.BPJSTenagaKerja).HasMaxLength(255);
            builder.Property(p => p.NPWP).HasMaxLength(255);
            builder.Property(p => p.NameBankAccount).HasMaxLength(255);
            builder.Property(p => p.Bank).HasMaxLength(15);
            builder.Property(p => p.BankAccountNumber).HasMaxLength(255);
            builder.Property(p => p.BankBranch).HasMaxLength(255);
            builder.Property(p => p.Allowance).HasMaxLength(255);
            builder.Property(p => p.Incentive).HasMaxLength(255);
            builder.Property(p => p.PaidLeave).HasMaxLength(255);
            builder.Property(p => p.SalaryPeriod).HasMaxLength(255);
        }
    }
}
