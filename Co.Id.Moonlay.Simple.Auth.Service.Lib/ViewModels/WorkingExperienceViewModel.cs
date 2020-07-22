using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels
{
    public class WorkingExperienceViewModel
    {
        public string company { get; set; }
        public string jobposition { get; set; }
        public DateTimeOffset? startDate { get; set; }
        public DateTimeOffset? endDate { get; set; }
        public string deskripsi { get; set; }
        public bool sertifikat { get; set; }
    }
}
