namespace RoleManager.Api.Profiles;

public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        CreateMap<Character, CharacterDto>();
        CreateMap<CharacterCreateDto, Character>();
        CreateMap<CharacterUpdateDto, Character>();
    }
}
