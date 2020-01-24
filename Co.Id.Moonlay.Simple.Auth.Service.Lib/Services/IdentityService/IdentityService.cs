using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Services.IdentityService
{
    public class IdentityService : IIdentityService
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public int TimezoneOffset { get; set; }
    }
}
