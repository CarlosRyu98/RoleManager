namespace RoleManager.Core.Models.Domain;

public class DomainDto
{
    public int DomainId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public List<int>? LocationIds { get; set; } = new List<int>();

    public List<int>? CharacterIds { get; set; } = new List<int>();

    public List<int>? FactionIds { get; set; } = new List<int>();

    public string? History { get; set; }

    public string? Objectives { get; set; }

    public int? CampaignId { get; set; }
}
