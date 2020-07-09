using Co.Id.Moonlay.Simple.Auth.Service.Lib.Utilities.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels
{
    public class EducationInfoViewModel 
    {
        //Education History
        public int no { get; set; }
        public string grade { get; set; }
        public string institution { get; set; }
        public string majors { get; set; }
        public int yearstart { get; set; }
        public int yearend { get; set; }

        //Informal Education History
        public string heldby { get; set; }
        public DateTimeOffset? startdate { get; set; }
        public DateTimeOffset? enddate { get; set; }
        public string fee { get; set; }
        public string description { get; set; }
        public bool certificate { get; set; }

        //Working Experience 
        public string company { get; set; }
        public string jobposition { get; set; }
        public string fromjob { get; set; }
        public string tojob { get; set; }
    }
}
