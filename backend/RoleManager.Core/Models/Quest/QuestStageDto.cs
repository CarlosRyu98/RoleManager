namespace RoleManager.Core.Models.Quest;

public class QuestStageDto
{
    public int StageId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    public int QuestId { get; set; } // ID de la misión a la que pertenece
}
