using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels.Forms
{
    public class PayslipFormViewModel : IValidatableObject
    {
        public string SalaryPeriod { get; set; }
        public string Fullname { get; set; }
        public string EmployeeID { get; set; }
        public string JobTitleName { get; set; }
        public string Department { get; set; }
        public string Bank { get; set; }
        public string BankAccountNumber { get; set; }

        //Payments
        public string Salary { get; set; }
        public DateTimeOffset BackDatedPayment { get; set; }
        public string Allowance { get; set; }
        public string Incentive { get; set; }
        public string PaidLeave { get; set; }

        //Decuction
        public string BPJSKesehatan { get; set; }
        public string BPJSTenagaKerja { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
