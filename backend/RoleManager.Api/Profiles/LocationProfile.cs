namespace RoleManager.Api.Profiles;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        CreateMap<Location, LocationDto>().ReverseMap();
        CreateMap<LocationCreateDto, Location>();
        CreateMap<LocationUpdateDto, Location>();
    }
}