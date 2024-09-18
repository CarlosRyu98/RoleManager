namespace RoleManager.Core.Models.Location;

public class LocationDto
{
    public int LocationId { get; set; }

    public int CampaignId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public int? DomainId { get; set; }

    public List<int>? CharacterIds { get; set; } = new List<int>();
}