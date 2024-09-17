namespace RoleManager.Core.Models.Character;

public class CharacterDto
{
    public int CharacterId { get; set; }

    public string? Name { get; set; }

    public string? Sex { get; set; }

    public string? Race { get; set; }

    public List<string>? Inventory { get; set; } = new List<string>();

    public List<string>? Proficiencies { get; set; } = new List<string>();

    public List<string>? Languages { get; set; } = new List<string>();

    public string? Backstory { get; set; }

    public string? Motivations { get; set; }

    public string? PersonalityTraits { get; set; }

    public string? PhysicalDescription { get; set; }

    public string? Quirks { get; set; }

    public string? Status { get; set; }

    public int CampaignId { get; set; }

    public int? FactionId { get; set; }

    public int? LocationId { get; set; }

    public List<int>? Allies { get; set; } = new List<int>(); // IDs de los aliados
    public List<int>? Rivals { get; set; } = new List<int>(); // IDs de los rivales
}
