using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels
{
    public class UnitViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public DivisionViewModel Division { get; set; }
    }
}
