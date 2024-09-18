namespace RoleManager.Api.Profiles;

public class CampaignProfile : Profile
{
    public CampaignProfile()
    {
        CreateMap<Campaign, CampaignDto>();
        CreateMap<CampaignCreateDto, Campaign>();
        CreateMap<CampaignUpdateDto, Campaign>();
    }
}