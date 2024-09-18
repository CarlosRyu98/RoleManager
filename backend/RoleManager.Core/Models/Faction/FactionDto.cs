namespace RoleManager.Core.Models.Faction;

public class FactionDto
{
    public int FactionId { get; set; }

    public int CampaignId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public int? LeaderId { get; set; }

    public string? Base { get; set; }

    public string? History { get; set; }

    public string? Objectives { get; set; }
}