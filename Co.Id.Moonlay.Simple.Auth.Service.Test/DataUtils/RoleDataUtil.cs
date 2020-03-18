using Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Services;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels;
using Co.Id.Moonlay.Simple.Auth.Service.Test.Utils;
using System.Collections.Generic;

namespace Co.Id.Moonlay.Simple.Auth.Service.Test.DataUtils
{
    public class RoleDataUtil : BaseDataUtil<Role, RoleViewModel, RoleService>
    {
        public RoleDataUtil() : base()
        {

        }
        public RoleDataUtil(RoleService service) : base(service)
        {
        }

        public override Role GetNewData()
        {
            return new Role()
            {
                Code = "code",
                Description = "desc",
                Name = "name",
                Permissions = new List<Permission>()
                {
                    new Permission()
                    {
                        DivisionName = "div",
                        permission = 1,
                        JobTitleName = "unit",
                        JobTitleCode = "unitcode",
                        JobTitleId = 1
                    }
                }
            };
        }

        public override RoleViewModel GetNewViewModel()
        {
            return new RoleViewModel()
            {
                code = "code",
                description = "desc",
                name = "name",
                permissions = new List<PermissionViewModel>()
                {
                    new PermissionViewModel()
                    {
                        permission = 1,
                        jobTitle = new JobTitleViewModel()
                        {
                            Id = 1,
                            Name = "name",
                            Code = "code",
                            Division = new JobTitleDivisionViewModel()
                            {
                                Name = "divName"
                            }
                        }
                    }
                }
            };
        }
    }
}
