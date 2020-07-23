using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Models
{
    public class AccountProfile : StandardEntity
    {
        public string Fullname { get; set; }
        public string EmployeeID { get; set; }
        public DateTimeOffset? Dob { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Email { get; set; }
        public string CoorporateEmail { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? JoinDate { get; set; }
        public string SkillSet { get; set; }
        public string FamilyData { get; set; }
        public string EmergencyContact { get; set; }
        public string EducationHistory { get; set; }
        public string InfromalEducationHistory { get; set; }
        public string WorkingEXP { get; set; }

        public int EducationInfoId { get; set; }

        public int FamilyId { get; set; }

        public int PayrollID { get; set; }

        public int AssetID { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public string UId { get; set; }



        public string JobTitleName { get; set; }
        public string Department { get; set; }

    }
}
