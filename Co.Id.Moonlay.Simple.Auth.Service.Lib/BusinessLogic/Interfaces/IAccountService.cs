using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Utilities.BaseInterface;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Interfaces
{
    public interface IAccountService : IBaseService<Account>
    {
        Task<Account> Authenticate(string username, string password);

        bool CheckDuplicate(int id, string username);

        Task<List<Account>> GetAccountByDivisionName(string divisionName);
    }
}
