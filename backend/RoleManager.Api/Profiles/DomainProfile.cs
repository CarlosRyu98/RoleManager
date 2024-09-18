namespace RoleManager.Api.Profiles;

public class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<Domain, DomainDto>().ReverseMap();
        CreateMap<DomainCreateDto, Domain>();
        CreateMap<DomainUpdateDto, Domain>();
    }
}