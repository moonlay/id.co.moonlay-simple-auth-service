using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Models
{
    public class WorkingExperience : StandardEntity
    {
        public string Company { get; set; }
        public string JobPositionExperience { get; set; }
        public DateTimeOffset? TanggalMulai { get; set; }
        public DateTimeOffset? TanggalSelesai { get; set; }
        public string Deskripsi { get; set; }
        public bool Sertifikat { get; set; }
    }
}
