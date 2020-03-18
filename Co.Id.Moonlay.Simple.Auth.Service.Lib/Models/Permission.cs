using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Models
{
    public class Permission : StandardEntity
    {
        public int JobTitleId { get; set; }
        public string JobTitleCode { get; set; }
        public string JobTitleName { get; set; }
        public string DivisionName { get; set; }
        public int permission { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public string UId { get; set; }

    }
}
