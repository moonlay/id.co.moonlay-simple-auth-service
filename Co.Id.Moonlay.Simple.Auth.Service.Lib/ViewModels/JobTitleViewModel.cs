using System;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels
{
    public class JobTitleViewModel
    {
        public JobTitleDivisionViewModel Division { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime LastModifiedUtc { get; set; }
    }
}