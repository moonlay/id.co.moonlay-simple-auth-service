using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.AutoMapperProfiles
{
    public class AccountProfile : BaseProfile
    {
        public AccountProfile() : base()
        {
            CreateMap<Models.AccountProfile, AccountProfileViewModel>()
                .ForPath(d => d.fullname, opt => opt.MapFrom(s => s.Fullname))
                .ForPath(d => d.employeeid, opt => opt.MapFrom(s => s.EmployeeID))
                .ForPath(d => d.dob, opt => opt.MapFrom(s => s.Dob))
                .ForPath(d => d.gender, opt => opt.MapFrom(s => s.Gender))
                .ForPath(d => d.religion, opt => opt.MapFrom(s => s.Religion))
                .ForPath(d => d.email, opt => opt.MapFrom(s => s.Email))
                .ForPath(d => d.password, opt => opt.MapFrom(s => s.Password))
                .ForPath(d => d.jobtitlename, opt => opt.MapFrom(s => s.JobTitleName))
                .ForPath(d => d.departmanet, opt => opt.MapFrom(s => s.Department))
                .ForPath(d => d.joindate, opt => opt.MapFrom(s => s.JoinDate))
                .ForPath(d => d.skillset, opt => opt.MapFrom(s => s.SkillSet))
                .ForPath(d => d.coorporateemail, opt => opt.MapFrom(s => s.CoorporateEmail))
                .ReverseMap();

            CreateMap<Models.Asset, AccountProfileViewModel>()
                .ForPath(d => d.assetname, opt => opt.MapFrom(s => s.AssetName))
                .ForPath(d => d.assetnumber, opt => opt.MapFrom(s => s.AssetNumber))
                .ReverseMap();

            CreateMap<Models.Payroll, AccountProfileViewModel>()
                .ForPath(d => d.salary, opt => opt.MapFrom(s => s.Salary))
                .ForPath(d => d.tax, opt => opt.MapFrom(s => s.Tax))
                .ForPath(d => d.bpjskesehatan, opt => opt.MapFrom(s => s.BPJSKesehatan))
                .ForPath(d => d.bpjstenagakerja, opt => opt.MapFrom(s => s.BPJSTenagaKerja))
                .ForPath(d => d.npwp, opt => opt.MapFrom(s => s.NPWP))
                .ForPath(d => d.namebankaccount, opt => opt.MapFrom(s => s.NameBankAccount))
                .ForPath(d => d.bank, opt => opt.MapFrom(s => s.Bank))
                .ForPath(d => d.bankaccountnumber, opt => opt.MapFrom(s => s.BankAccountNumber))
                .ForPath(d => d.bankbranch, opt => opt.MapFrom(s => s.BankBranch))
                .ReverseMap();

            CreateMap<AccountRole, RoleViewModel>()
                .ForPath(d => d.code, opt => opt.MapFrom(s => s.Role.Code))
                .ForPath(d => d.description, opt => opt.MapFrom(s => s.Role.Description))
                .ForPath(d => d.name, opt => opt.MapFrom(s => s.Role.Name))
                .ForPath(d => d._id, opt => opt.MapFrom(s => s.RoleId))
                .ForPath(d => d.permissions, opt => opt.MapFrom(s => s.Role.Permissions))
                .ReverseMap();

            CreateMap<Permission, PermissionViewModel>()
                .ForPath(d => d.id, opt => opt.MapFrom(s => s.Id))
                .ForPath(d => d.permission, opt => opt.MapFrom(s => s.permission))
                .ForPath(d => d.roleId, opt => opt.MapFrom(s => s.RoleId))
                .ForPath(d => d.jobTitle.Code, opt => opt.MapFrom(s => s.JobTitleCode))
                .ForPath(d => d.jobTitle.Name, opt => opt.MapFrom(s => s.JobTitleName))
                .ForPath(d => d.jobTitle.Id, opt => opt.MapFrom(s => s.JobTitleId))
                .ForPath(d => d.jobTitle.Division.Name, opt => opt.MapFrom(s => s.DivisionName))
                .ReverseMap();

            CreateMap<Account, AccountViewModel>()
                .ForPath(d => d.username, opt => opt.MapFrom(s => s.Username))
                .ForPath(d => d.password, opt => opt.MapFrom(s => s.Password))
                .ForPath(d => d.isLocked, opt => opt.MapFrom(s => s.IsLocked))
                .ForPath(d => d.profile, opt => opt.MapFrom(s => s.AccountProfile))
                .ForPath(d => d.roles, opt => opt.MapFrom(s => s.AccountRoles))
                .ReverseMap();


        }
    }
}
