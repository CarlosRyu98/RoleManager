namespace RoleManager.Core.Models.Campaign;

public class CampaignDto
{
    public int CampaignId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? History { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public List<int>? CharacterIds { get; set; }
    public List<int>? FactionIds { get; set; }
    public List<int>? DomainIds { get; set; }
    public List<int>? LocationIds { get; set; }
    public List<int>? QuestIds { get; set; }
}
