using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels.Forms
{
    public class AccountProfileFormViewModel : IValidatableObject
    {
        public string Fullname { get; set; }
        public string EmployeeId { get; set; }
        public DateTimeOffset? DOB { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Employee Data
        public string JobTitlename { get; set; }
        public string Departmanet { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? JoinDate { get; set; }
        public string CoorporateEmail { get; set; }
        public string SkillSet { get; set; }

        //Assets
        public string AssetName { get; set; }
        public int AssetNumber { get; set; }

        //Payroll
        public string Salary { get; set; }
        public string Tax { get; set; }
        public string BPJSKesehatan { get; set; }
        public string BPJSTenagakerja { get; set; }
        public string NPWP { get; set; }
        public string NameBankAccount { get; set; }
        public string Bank { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankBranch { get; set; }
        //public int AccountId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
