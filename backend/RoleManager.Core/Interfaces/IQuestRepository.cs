namespace RoleManager.Core.Interfaces;

public interface IQuestRepository
{
    Task<IEnumerable<Quest>> GetAllQuestsAsync();

    Task<Quest?> GetQuestByIdAsync(int questId);

    Task<IEnumerable<Quest>> GetQuestsByCampaignAsync(int campaignId); // Nuevo método

    Task<Quest> CreateQuestAsync(Quest quest);

    Task<bool> UpdateQuestAsync(Quest quest);

    Task<bool> DeleteQuestAsync(int questId);
}

public interface IQuestStageRepository
{
    Task<IEnumerable<QuestStage>> GetStagesByQuestIdAsync(int questId); // Obtener etapas por QuestId

    Task<QuestStage?> GetStageByIdAsync(int stageId);  // Obtener etapa por ID

    Task<QuestStage> CreateStageAsync(QuestStage stage);  // Crear etapa

    Task<bool> UpdateStageAsync(QuestStage stage);  // Actualizar etapa

    Task<bool> DeleteStageAsync(int stageId);  // Eliminar etapa
}