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
            CreateMap<Individual, IndividualModel>().ReverseMap();
            //CreateMap<City, CityModel>().ReverseMap()
        }
    }
}
