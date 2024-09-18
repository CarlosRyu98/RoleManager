namespace RoleManager.Core.Interfaces;

public interface IQuestRepository
{
    Task<IEnumerable<Quest>> GetAllQuestsAsync();

    Task<Quest?> GetQuestByIdAsync(int questId);

    Task<Quest> CreateQuestAsync(Quest quest);

    Task<bool> UpdateQuestAsync(Quest quest);

    Task<bool> DeleteQuestAsync(int questId);
}

public interface IQuestStageRepository
{
    Task<IEnumerable<QuestStage>> GetStagesByQuestIdAsync(int questId);

    Task<QuestStage?> GetStageByIdAsync(int stageId);

    Task<QuestStage> CreateStageAsync(QuestStage stage);

    Task<bool> UpdateStageAsync(QuestStage stage);

    Task<bool> DeleteStageAsync(int stageId);
}