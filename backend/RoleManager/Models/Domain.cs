namespace RoleManager.Models;

public class Domain
{
    [Key]
    public int DomainId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no debe superar los 500 caracteres.")]
    public string? Description { get; set; }

    [StringLength(100, ErrorMessage = "El tipo no debe superar los 100 caracteres.")]
    public string? Type { get; set; } // Ej. "Reino", "Federación"

    public List<int>? LocationIds { get; set; } = new List<int>(); // IDs de localizaciones asociadas
    public virtual List<Location>? Locations { get; set; } = new List<Location>(); // Navegación a localizaciones

    public List<int>? CharacterIds { get; set; } = new List<int>(); // IDs de personajes en este dominio
    public virtual List<Character>? Characters { get; set; } = new List<Character>(); // Navegación a personajes

    public List<int>? FactionIds { get; set; } = new List<int>(); // IDs de facciones en este dominio
    public virtual List<Faction>? Factions { get; set; } = new List<Faction>(); // Navegación a facciones

    [StringLength(1000, ErrorMessage = "La historia no debe superar los 1000 caracteres.")]
    public string? History { get; set; }

    [StringLength(500, ErrorMessage = "Los objetivos no deben superar los 500 caracteres.")]
    public string? Objectives { get; set; }
    [Required]
    public int? CampaignId { get; set; } // ID de la campaña a la que pertenece el dominio
}
