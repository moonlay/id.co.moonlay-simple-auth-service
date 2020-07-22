using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels.Forms
{
    public class EducationInfoFormViewModel : IValidatableObject
    {
        public int EducationInfoId { get; set; }
        public string Grade { get; set; }
        public string Institution { get; set; }
        public string Majors { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
