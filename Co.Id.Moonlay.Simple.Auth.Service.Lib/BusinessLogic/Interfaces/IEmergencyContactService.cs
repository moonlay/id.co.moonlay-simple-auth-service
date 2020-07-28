using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Utilities.BaseInterface;
using Com.Moonlay.NetCore.Lib.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Interfaces
{
    public interface IEmergencyContactService : IBaseService<EmergencyContact>
    {
        bool CheckDuplicate(int id);
    }
}
