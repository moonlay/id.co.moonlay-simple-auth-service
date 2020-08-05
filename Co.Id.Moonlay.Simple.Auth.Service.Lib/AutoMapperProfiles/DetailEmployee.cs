﻿using System;
using System.Collections.Generic;
using System.Text;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.Models;
using Co.Id.Moonlay.Simple.Auth.Service.Lib.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.AutoMapperProfiles
{
    public class DetailEmployee : BaseProfile
    {
        public DetailEmployee() : base()
        {
            //Employement Data
            CreateMap<Models.AccountProfile, AccountProfileViewModel>()
                .ForPath(d => d.jobtitlename, opt => opt.MapFrom(s => s.JobTitleName))
                .ForPath(d => d.departmanet, opt => opt.MapFrom(s => s.Department))
                .ForPath(d => d.status, opt => opt.MapFrom(s => s.Status))
                .ForPath(d => d.joindate, opt => opt.MapFrom(s => s.JoinDate))
                .ForPath(d => d.skillset, opt => opt.MapFrom(s => s.SkillSet))
                .ReverseMap();

            //Personal Data
            CreateMap<Models.AccountProfile, AccountProfileViewModel>()
                .ForPath(d => d.employeeid, opt => opt.MapFrom(s => s.EmployeeID))
                .ForPath(d => d.fullname, opt => opt.MapFrom(s => s.Fullname))
                .ForPath(d => d.gender, opt => opt.MapFrom(s => s.Gender))
                .ForPath(d => d.dob, opt => opt.MapFrom(s => s.Dob))
                .ForPath(d => d.religion, opt => opt.MapFrom(s => s.Religion))
                .ReverseMap();

            //Family Data
            CreateMap<Models.FamilyData, FamilyDataViewModels>()
                .ForPath(d => d.fullNameOfFamily, opt => opt.MapFrom(s => s.FullNameOfFamily))
                .ForPath(d => d.relationship, opt => opt.MapFrom(s => s.Relationship))
                .ForPath(d => d.DobFamily, opt => opt.MapFrom(s => s.DOBFamily))
                .ForPath(d => d.religion, opt => opt.MapFrom(s => s.Religion))
                .ForPath(d => d.gender, opt => opt.MapFrom(s => s.Gender))
                .ForPath(d => d.ktpNumber, opt => opt.MapFrom(s => s.KTPNumber))

                //Emergency Contact
                .ForPath(d => d.relationship, opt => opt.MapFrom(s => s.Relationship))
                .ReverseMap();

            //Education Info
            CreateMap<Models.EducationInfo, EducationInfoViewModel>()
                .ForPath(d => d.grade, opt => opt.MapFrom(s => s.Grade))
                .ForPath(d => d.institution, opt => opt.MapFrom(s => s.Institution))
                .ForPath(d => d.majors, opt => opt.MapFrom(s => s.Majors))
                .ForPath(d => d.yearstart, opt => opt.MapFrom(s => s.YearStart))
                .ForPath(d => d.yearend, opt => opt.MapFrom(s => s.YearEnd))
                .ReverseMap();

            //Informal Education Info
            CreateMap<Models.InformalEducation, EducationInfoViewModel>()
                .ForPath(d => d.heldby, opt => opt.MapFrom(s => s.HeldBy))
                .ForPath(d => d.startdate, opt => opt.MapFrom(s => s.StartDate))
                .ForPath(d => d.enddate, opt => opt.MapFrom(s => s.EndDate))
                .ForPath(d => d.description, opt => opt.MapFrom(s => s.Description))
                .ForPath(d => d.certificate, opt => opt.MapFrom(s => s.Certificate))
                .ReverseMap();

            //Working Experience
            CreateMap<Models.WorkingExperience, WorkingExperienceViewModel>()
                .ForPath(d => d.company, opt => opt.MapFrom(s => s.Company))
                .ForPath(d => d.jobposition, opt => opt.MapFrom(s => s.JobPositionExperience))
                .ForPath(d => d.startDate, opt => opt.MapFrom(s => s.TanggalMulai))
                .ForPath(d => d.endDate, opt => opt.MapFrom(s => s.TanggalSelesai))
                .ForPath(d => d.deskripsi, opt => opt.MapFrom(s => s.Deskripsi))
                .ForPath(d => d.sertifikat, opt => opt.MapFrom(s => s.Sertifikat))
                .ReverseMap();
        }
    }
}
