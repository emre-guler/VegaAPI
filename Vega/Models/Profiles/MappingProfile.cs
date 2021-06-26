using AutoMapper;
using Vega.DTO;
using Vega.Entities;

namespace Vega.Data.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, MostWinnersDTO>();
        }
    }
}