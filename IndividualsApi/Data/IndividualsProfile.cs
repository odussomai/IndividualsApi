using AutoMapper;
using IndividualsApi.Data.Entities;
using IndividualsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualsApi.Data
{
    public class IndividualsProfile : Profile
    {
        public IndividualsProfile()
        {
            CreateMap<Individual, IndividualModel>()
                .ForMember(i => i.Phones, p => p.MapFrom(a => a.PhoneNumbers))
                .ForMember(m => m.CityId, p => p.MapFrom(a => a.City.Id))
                .ForMember(m => m.CityName, p => p.MapFrom(a => a.City.Name))
                .ReverseMap();

            CreateMap<Phone, PhoneModel>()
                .ForMember(m => m.PhoneNumber, s => s.MapFrom(d => d.PhoneNumber))
                .ForMember(m => m.Type, s => s.MapFrom(d => d.Type))
                .ReverseMap();

            //CreateMap<City, CityModel>().ReverseMap()
        }
    }
}
