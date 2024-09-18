namespace RoleManager.Infrastructure.Repositories;

public class QuestRepository : IQuestRepository
{
    private readonly RoleManagerDbContext _context;

    public QuestRepository(RoleManagerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Quest>> GetAllQuestsAsync()
    {
        return await _context.Quests.Include(q => q.Stages).ToListAsync();
    }

    public async Task<Quest?> GetQuestByIdAsync(int questId)
    {
        return await _context.Quests.Include(q => q.Stages)
            .FirstOrDefaultAsync(q => q.QuestId == questId);
    }

    public async Task<IEnumerable<Quest>> GetQuestsByCampaignAsync(int campaignId)
    {
        return await _context.Quests.Where(q => q.CampaignId == campaignId).Include(q => q.Stages).ToListAsync();
    }

    public async Task<Quest> CreateQuestAsync(Quest quest)
    {
        _context.Quests.Add(quest);
        await _context.SaveChangesAsync();
        return quest;
    }

    public async Task<bool> UpdateQuestAsync(Quest quest)
    {
        _context.Quests.Update(quest);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteQuestAsync(int questId)
    {
        var quest = await _context.Quests.FindAsync(questId);
        if (quest == null) return false;

        _context.Quests.Remove(quest);
        return await _context.SaveChangesAsync() > 0;
    }
}

public class QuestStageRepository : IQuestStageRepository
{
    private readonly RoleManagerDbContext _context;

    public QuestStageRepository(RoleManagerDbContext context)
    {
        _context = context;
    }

    // Obtener etapas por questId
    public async Task<IEnumerable<QuestStage>> GetStagesByQuestIdAsync(int questId)
    {
        // Filtrar las etapas relacionadas con una quest específica
        return await _context.QuestStages
            .Where(s => s.QuestId == questId) // Filtrado por QuestId
            .ToListAsync();
    }

    // Obtener etapa por ID
    public async Task<QuestStage?> GetStageByIdAsync(int stageId)
    {
        return await _context.QuestStages.FindAsync(stageId);
    }

    // Crear una nueva etapa
    public async Task<QuestStage> CreateStageAsync(QuestStage stage)
    {
        _context.QuestStages.Add(stage);
        await _context.SaveChangesAsync();
        return stage;
    }

    // Actualizar una etapa
    public async Task<bool> UpdateStageAsync(QuestStage stage)
    {
        _context.QuestStages.Update(stage);
        return await _context.SaveChangesAsync() > 0;
    }

    // Eliminar una etapa
    public async Task<bool> DeleteStageAsync(int stageId)
    {
        var stage = await _context.QuestStages.FindAsync(stageId);
        if (stage == null) return false;

        _context.QuestStages.Remove(stage);
        return await _context.SaveChangesAsync() > 0;
    }
}