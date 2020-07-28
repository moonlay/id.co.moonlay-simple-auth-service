using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels.Forms
{
    public class AssetFormViewModel : IValidatableObject
    {
        public int AssetNumber { get; set; }
        public string AssetType { get; set; }
        public string AssetName { get; set; }
        public DateTimeOffset? AcquisitionDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
