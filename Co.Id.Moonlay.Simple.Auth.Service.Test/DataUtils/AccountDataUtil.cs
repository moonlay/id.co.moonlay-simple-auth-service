using Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Services;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels;
using Co.Id.Moonlay.Simple.Auth.Service.Test.Utils;
using System;
using System.Collections.Generic;

namespace Co.Id.Moonlay.Simple.Auth.Service.Test.DataUtils
{
    public class AccountDataUtil : BaseDataUtil<Account, AccountViewModel, AccountService>
    {
        public AccountDataUtil() : base()
        {

        }
        public AccountDataUtil(AccountService service) : base(service)
        {

        }

        public override Account GetNewData()
        {
            return new Account()
            {
                Username = "username",
                Password = "password",
                IsLocked = false,
                AccountProfile = new AccountProfile()
                {
                    Dob = DateTimeOffset.UtcNow,
                    Email = "email",
                    Gender = "male",
                    Fullname = "fullname",
                    EmployeeID = "employeeid"
                },
                AccountRoles = new List<AccountRole>()
            };
        }

        public override AccountViewModel GetNewViewModel()
        {
            return new AccountViewModel()
            {
                username = "username",
                password = "password",
                isLocked = false,
                profile = new AccountProfileViewModel()
                {
                    dob = DateTimeOffset.UtcNow,
                    email = "email",
                    fullname = "fullname",
                    gender = "gender",
                    employeeid = "employeeid"
                },
                roles = new List<RoleViewModel>()
            };
        }
    }
}
