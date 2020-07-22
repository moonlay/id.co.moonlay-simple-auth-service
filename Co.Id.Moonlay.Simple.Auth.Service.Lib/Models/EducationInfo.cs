using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Models
{
    public class EducationInfo : StandardEntity
    {
        //Education History
        public int EducationInfoId { get; set; }
        public string Grade { get; set; }
        public string Institution { get; set; }
        public string Majors { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }

    }
}
