using AutoMapper;
using IndividualsApi.Data.Entities;

namespace IndividualsApi.Models
{
    public class IndividualsProfile : Profile
    {
        public IndividualsProfile()
        {
            CreateMap<Individual, IndividualModel>()
                .ForMember(i => i.Phones, p => p.MapFrom(a => a.PhoneNumbers))
                .ForMember(m => m.CityId, p => p.MapFrom(a => a.City.Id))
                .ForMember(m => m.CityName, p => p.MapFrom(a => a.City.Name))
                .ForMember(m => m.Relations, p => p.MapFrom(a => a.Relatives))
                .ReverseMap()
                .ForMember(m => m.City, p =>p.Ignore());

            CreateMap<Phone, PhoneModel>()
                .ForMember(m => m.PhoneNumber, s => s.MapFrom(d => d.PhoneNumber))
                .ForMember(m => m.Type, s => s.MapFrom(d => d.Type))
                .ReverseMap();

            CreateMap<Relation, RelationModel>()
                .ForMember(a => a.Related, c => c.MapFrom(m => m.Relative))
                .ForMember(a => a.Type, c => c.MapFrom(m => m.Type));

            //CreateMap<City, CityModel>().ReverseMap()
        }
    }
}
