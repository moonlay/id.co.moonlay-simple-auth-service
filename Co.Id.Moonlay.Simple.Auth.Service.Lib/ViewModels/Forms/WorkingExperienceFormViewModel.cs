using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels.Forms
{
    public class WorkingExperienceFormViewModel : IValidatableObject
    {
        public string Company { get; set; }
        public string JobPosition { get; set; }
        public DateTimeOffset? TanggalMulai { get; set; }
        public DateTimeOffset? TanggalSelesai { get; set; }
        public string Deskripsi { get; set; }
        public bool? Sertifikat { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
