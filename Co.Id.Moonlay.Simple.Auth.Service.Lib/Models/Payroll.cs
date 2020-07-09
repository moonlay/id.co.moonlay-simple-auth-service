using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Models
{
    public class Payroll : StandardEntity
    {
        public int PayrollID { get; set; }
        public string Salary { get; set; }
        public string Tax { get; set; }
        public string BPJSKesehatan { get; set; }
        public string BPJSTenagaKerja { get; set; }
        public string NPWP { get; set; }
        public string NameBankAccount { get; set; }
        public string Bank { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankBranch { get; set; }
        public DateTimeOffset BackDatedPayment { get; set; }
        public string Allowance { get; set; }
        public string Incentive { get; set; }
        public string PaidLeave { get; set; }
        public string SalaryPeriod { get; set; }
    }
}
