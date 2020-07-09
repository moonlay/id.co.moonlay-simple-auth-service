using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Utilities.BaseInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Interfaces
{
    public interface IAccountProfileService : IBaseService<AccountProfile>
    {
        bool CheckDuplicate(int id, string fullname, string email);
        Task<List<AccountProfile>>GetAccountProfileByFullName(string fullname);
        Task<List<AccountProfile>> GetAccountProfilesByReligion(string religion);
    }
}
