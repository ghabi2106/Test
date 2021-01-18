using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Application.ViewModels;
using Test.Domain.Models;

namespace Test.Application.Infra.Ioc
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<City, CityDto>();
        } 
    }
}
