using AutoMapper;
using yummer_backend.Models;
using yummer_backend.Models.DTOs;

namespace yummer_backend;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDto, User>()
            .ForMember(dest => dest.PasswordHash, 
                opt => 
                    opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.UserName,
                opt => 
                    opt.MapFrom(src => src.Email));

        CreateMap<ItemDto, Item>();
    }
}