using AutoMapper;
using Games_Storage.Core.Models;
using Games_Storage.Core.Services.Dtos;

namespace Games_Storage.Core.Services.Mapper.MappingProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();
        }
    }
}
