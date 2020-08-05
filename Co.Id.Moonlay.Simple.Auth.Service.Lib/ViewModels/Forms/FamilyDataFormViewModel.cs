using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels.Forms
{
    public class FamilyDataFormViewModel : IValidatableObject
    {
        public string FullNameOfFamily { get; set; }
        public string Relationship { get; set; }
        public DateTimeOffset? DOBFamily { get; set; }
        public string Religion { get; set; }
        public string Gender { get; set; }
        public string KTPNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
