using Co.Id.Moonlay.Simple.Auth.Service.Lib.Utilities.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels
{
    public class AccountProfileViewModel 
    {
        //Personal Data
        public int id { get; set; }
        public string fullname { get; set; }
        public string employeeid { get; set; }
        public DateTimeOffset? dob { get; set; }
        public string gender { get; set; }
        public string religion { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        //Employee Data
        public string jobtitlename { get; set; }
        public string departmanet { get; set; }
        public string status { get; set; }
        public DateTimeOffset? joindate { get; set; }
        public string coorporateemail { get; set; }
        public string skillset { get; set; }

        //Assets
        public string assetname { get; set; }
        public int assetnumber { get; set; }

        //Payroll
        public string salary { get; set; }
        public string tax { get; set; }
        public string bpjskesehatan { get; set; }
        public string bpjstenagakerja { get; set; }
        public string npwp { get; set; }
        public string namebankaccount { get; set; }
        public string bank { get; set; }
        public string bankaccountnumber { get; set; }
        public string bankbranch { get; set; }

    }
}
