using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Models
{
    public class InformalEducation : StandardEntity
    {
        public string HeldBy { get; set; }
        public string JobPosition { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string Description { get; set; }
        public bool Certificate { get; set; }
        public string FileURL { get; set; }
    }
}
