namespace RoleManager.Models;

public class Location
{
    [Key]
    public int LocationId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no debe superar los 500 caracteres.")]
    public string? Description { get; set; }

    public int? DomainId { get; set; } // ID del dominio al que pertenece
    public virtual Domain? Domain { get; set; } // Navegación al dominio

    public List<int>? CharacterIds { get; set; } = new List<int>(); // IDs de personajes en esta localización
    public virtual List<Character>? Characters { get; set; } = new List<Character>(); // Navegación a personajes

    [Required]
    public int? CampaignId { get; set; } // ID de la campaña a la que pertenece el location

}
