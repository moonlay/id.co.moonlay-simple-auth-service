using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Utilities.BaseInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Interfaces
{
    public interface IInformalEducationService : IBaseService<InformalEducation>
    {
        bool CheckDuplicate(int id);
    }
}
