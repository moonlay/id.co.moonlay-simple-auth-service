using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Co.Id.Moonlay.Simple.Auth.Service.WebApi.Utilities
{
    public interface ISecret
    {
        string SecretString { get; }
    }
}
