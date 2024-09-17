namespace RoleManager.Core.Entities;

public class Campaign
{
    [Key]
    public int CampaignId { get; set; }

    [Required(ErrorMessage = "El nombre de la campaña es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no debe superar los 500 caracteres.")]
    public string? Description { get; set; }

    [StringLength(500, ErrorMessage = "La historia no debe superar los 500 caracteres.")]
    public string? History { get; set; }

    [StringLength(300, ErrorMessage = "Los objetivos no deben superar los 300 caracteres.")]

    public List<int>? CharacterIds { get; set; } = new List<int>();
    public virtual List<Character>? Characters { get; set; } = new List<Character>();

    public List<int>? FactionIds { get; set; } = new List<int>();
    public virtual List<Faction>? Factions { get; set; } = new List<Faction>();

    public List<int>? DomainIds { get; set; } = new List<int>();
    public virtual List<Domain>? Domains { get; set; } = new List<Domain>();

    public List<int>? LocationIds { get; set; } = new List<int>();
    public virtual List<Location>? Locations { get; set; } = new List<Location>();

    public List<int>? QuestIds { get; set; } = new List<int>();
    public virtual List<Quest>? Quests { get; set; } = new List<Quest>();
}
