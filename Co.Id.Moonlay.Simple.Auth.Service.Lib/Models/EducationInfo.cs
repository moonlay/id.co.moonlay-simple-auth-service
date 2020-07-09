using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Models
{
    public class EducationInfo : StandardEntity
    {
        //Education History
        public int no { get; set; }
        public string Grade { get; set; }
        public string Institution { get; set; }
        public string Majors { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }

        //Informal Education History
        public string HeldBy { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string Fee { get; set; }
        public string Description { get; set; }
        public bool Certificate { get; set; }

        //Working Experience 
        public string Company { get; set; }
        public string JobPosition { get; set; }
        public string FromJob { get; set; }
        public string ToJob { get; set; }

    }
}
