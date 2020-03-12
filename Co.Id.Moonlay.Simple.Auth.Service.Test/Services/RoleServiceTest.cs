﻿using AutoMapper;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Services;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels;
using Co.Id.Moonlay.Simple.Auth.Service.Test.DataUtils;
using Co.Id.Moonlay.Simple.Auth.Service.Test.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Xunit;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.BusinessLogic.Interfaces;

namespace Co.Id.Moonlay.Simple.Auth.Service.Test.Services
{
    public class RoleServiceTest : BaseServiceTest<Role, RoleViewModel, RoleService, RoleDataUtil>
    {
        public RoleServiceTest() : base("Role")
        {
        }

        protected override Role OnUpdating(Role model)
        {
            model.Name += "[updated]";
            return model;
        }

        [Fact]
        public void Mapping_With_AutoMapper_Profiles()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Lib.AutoMapperProfiles.RoleProfile>();
                cfg.AddProfile<Lib.AutoMapperProfiles.AccountProfile>();
            });
            var mapper = configuration.CreateMapper();

            RoleViewModel vm = new RoleViewModel { _id = 1 };
            Role model = mapper.Map<Role>(vm);

            Assert.Equal(vm._id, model.Id);

        }

        public override async void Should_Success_Validate_All_Null_Data()
        {
            var serviceProvider = GetServiceProvider();
            var service = GetService(serviceProvider.Object, _dbContext(GetCurrentMethod()));
            serviceProvider.Setup(s => s.GetService(typeof(IRoleService)))
                .Returns(service);
            var vm = new RoleViewModel();
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(vm, serviceProvider.Object, null);
            Assert.True(vm.Validate(context).Count() > 0);

            var data = await _dataUtil(service).GetTestData();

            vm.code = data.Code;
            Assert.True(vm.Validate(context).Count() > 0);

            vm.permissions = new List<PermissionViewModel>()
            {
                new PermissionViewModel()
                {
                    unit = new UnitViewModel()
                }
            };
            Assert.True(vm.Validate(context).Count() > 0);
            vm.permissions = new List<PermissionViewModel>()
            {
                new PermissionViewModel()
                {
                    roleId = 1,
                    _createAgent = "a",
                    _createdBy = "a",
                    _createdDate = DateTime.UtcNow,
                    id = 1,
                    unit = new UnitViewModel()
                    {
                        Name = "err"
                    }
                }
            };
            Assert.True(vm.Validate(context).Count() > 0);
        }
    }
}
