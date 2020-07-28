using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels.Forms
{
    public class EmployeeDataFormViewModel : IValidatableObject
    {
        public string JobTitleName { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? JoinDate { get; set; }
        public string CoorporateEmail { get; set; }
        public string SkillSet { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
