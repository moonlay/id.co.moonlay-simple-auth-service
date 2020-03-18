using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.AutoMapperProfiles
{
    public class RoleProfile : BaseProfile
    {
        public RoleProfile() : base()
        {
            CreateMap<Permission, PermissionViewModel>()
                .ForPath(d => d.id, opt => opt.MapFrom(s => s.Id))
                .ForPath(d => d.permission, opt => opt.MapFrom(s => s.permission))
                .ForPath(d => d.roleId, opt => opt.MapFrom(s => s.RoleId))
                .ForPath(d => d.jobTitle.Code, opt => opt.MapFrom(s => s.JobTitleCode))
                .ForPath(d => d.jobTitle.Division.Name, opt => opt.MapFrom(s => s.DivisionName))
                .ForPath(d => d.jobTitle.Name, opt => opt.MapFrom(s => s.JobTitleName))
                .ForPath(d => d.jobTitle.Id, opt => opt.MapFrom(s => s.JobTitleId))
                .ForPath(d => d._createAgent, opt => opt.MapFrom(s => s.CreatedAgent))
                .ForPath(d => d._createdBy, opt => opt.MapFrom(s => s.CreatedBy))
                .ForPath(d => d._createdDate, opt => opt.MapFrom(s => s.CreatedUtc))
                .ReverseMap();

            CreateMap<Role, RoleViewModel>()
                .ForPath(d => d.code, opt => opt.MapFrom(s => s.Code))
                .ForPath(d => d.description, opt => opt.MapFrom(s => s.Description))
                .ForPath(d => d.name, opt => opt.MapFrom(s => s.Name))
                .ForPath(d => d.permissions, opt => opt.MapFrom(s => s.Permissions))
                .ReverseMap();
        }
    }
}
