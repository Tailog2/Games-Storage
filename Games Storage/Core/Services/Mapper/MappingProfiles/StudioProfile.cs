using AutoMapper;
using Games_Storage.Core.Models;
using Games_Storage.Core.Services.Dtos;

namespace Games_Storage.Core.Services.Mapper.MappingProfiles
{
    public class StudioProfile : Profile
    {
        public StudioProfile()
        {
            CreateMap<Studio, StudioDto>();
            CreateMap<StudioDto, Studio>()
                .ForMember(s => s.Id, opt => opt.Ignore());
        }
    }
}
