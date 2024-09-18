namespace RoleManager.Core.Models.Quest;

public class QuestDto
{
    public int QuestId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    public int CampaignId { get; set; }

    public List<int>? Stages { get; set; } = new List<int>(); // IDs de las etapas asociadas
}