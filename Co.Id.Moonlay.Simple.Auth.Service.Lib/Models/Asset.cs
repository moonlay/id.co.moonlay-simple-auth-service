using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Models
{
    public class Asset : StandardEntity
    {
        public int AssetID { get; set; }
        public int AssetNumber { get; set; }
        public string AssetType { get; set; }
        public string AssetName { get; set; }
        public string FullNameEmployeeAsset { get; set; }
        public DateTimeOffset? AcquisitionDate { get; set; }
    }
}
