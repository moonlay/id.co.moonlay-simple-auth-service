using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Co.Id.Moonlay.Simple.Auth.Service.WebApi.Utilities
{
    public class Secret : ISecret
    {
        public IConfiguration Configuration;
        public Secret(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string SecretString => Configuration.GetConnectionString(Constant.SECRET) ?? Configuration[Constant.SECRET];
    }
}
