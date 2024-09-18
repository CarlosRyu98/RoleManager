namespace RoleManager.Api.Profiles;

public class QuestProfile : Profile
{
    public QuestProfile()
    {
        CreateMap<Quest, QuestDto>().ReverseMap();
        CreateMap<QuestCreateDto, Quest>();
        CreateMap<QuestUpdateDto, Quest>();

        CreateMap<QuestStage, QuestStageDto>().ReverseMap();
        CreateMap<QuestStageCreateDto, QuestStage>();
        CreateMap<QuestStageUpdateDto, QuestStage>();
    }
}