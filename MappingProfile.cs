using AutoMapper;
using yummer_backend.Models;
using yummer_backend.Models.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDto, User>();
    }
}
