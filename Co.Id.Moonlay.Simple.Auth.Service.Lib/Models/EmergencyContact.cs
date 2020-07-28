using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Models
{
    public class EmergencyContact : StandardEntity
    {
        public string NameOfContact { get; set; }
        public string Relationship { get; set; }
        public string PhoneNumber { get; set; }
    }
}
