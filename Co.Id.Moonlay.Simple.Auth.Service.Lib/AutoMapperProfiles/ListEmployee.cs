using System;
using System.Collections.Generic;
using System.Text;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.AutoMapperProfiles
{
    public class ListEmployee : BaseProfile
    {
        public ListEmployee() : base()
        {
            CreateMap<Models.AccountProfile, AccountProfileViewModel>()
                .ForPath(d => d.fullname, opt => opt.MapFrom(s => s.Fullname))
                .ForPath(d => d.employeeid, opt => opt.MapFrom(s => s.EmployeeID))
                .ForPath(d => d.gender, opt => opt.MapFrom(s => s.Gender))
                .ForPath(d => d.religion, opt => opt.MapFrom(s => s.Religion))
                .ForPath(d => d.dob, opt => opt.MapFrom(s => s.Dob))
                .ForPath(d => d.email, opt => opt.MapFrom(s => s.Email))
                .ForPath(d => d.jobtitlename, opt => opt.MapFrom(s => s.JobTitleName))
                .ForPath(d => d.status, opt => opt.MapFrom(s => s.Status))
                .ReverseMap();
        }
    }
}
