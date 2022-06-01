using AutoMapper;
using Games_Storage.Core.Models;
using Games_Storage.Core.Services.Dtos;

namespace Games_Storage.Core.Services.Mapper.MappingProfiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>()
                .ForMember(gDto => gDto.Genres, opt => opt
                .MapFrom((g, gDto) => gDto.Genres = g.GamesGenres
                    .Select(gg => new GenreDto() { Name = gg.Genre.Name, Id = gg.Genre.Id })));

            CreateMap<NewGameDto, Game>()
                .ForMember(gDto => gDto.GamesGenres, opt => opt
                .MapFrom((gDto, g) => g.GamesGenres = gDto.GenresIds
                    .Select(id => new GamesGenres() { GamesId = g.Id, GenresId = id })));

            CreateMap<EditGameDto, Game>()
                .ForMember(gDto => gDto.GamesGenres, opt => opt
                .MapFrom((gDto, g) => g.GamesGenres = gDto.GenresIds
                    .Select(id => new GamesGenres() { GamesId = g.Id, GenresId = id })));
        }
    }
}
