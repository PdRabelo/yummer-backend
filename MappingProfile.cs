using AutoMapper;
using yummer_backend.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDto, User>();
    }
}
