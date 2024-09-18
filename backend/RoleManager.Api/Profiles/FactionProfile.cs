namespace RoleManager.Api.Profiles;

public class FactionProfile : Profile
{
    public FactionProfile()
    {
        CreateMap<Faction, FactionDto>().ReverseMap();
        CreateMap<FactionCreateDto, Faction>();
        CreateMap<FactionUpdateDto, Faction>();
    }
}