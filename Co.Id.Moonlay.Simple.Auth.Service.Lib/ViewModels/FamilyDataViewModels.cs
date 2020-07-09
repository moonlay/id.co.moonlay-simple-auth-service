using Co.Id.Moonlay.Simple.Auth.Service.Lib.Utilities.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels
{
    public class FamilyDataViewModels
    {
        public int id { get; set; }
        public string fullNameOfFamily { get; set; }
        public string relationship { get; set; }
        public DateTimeOffset? DobFamily { get; set; }
        public string religion { get; set; }
        public string gender { get; set; }
        public string ktpNumber { get; set; }

        //Emergency Contact
        public int no { get; set; }
        public string nameOfcontact { get; set; }
        public string phonenumber { get; set; }
    }
}
