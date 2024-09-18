namespace RoleManager.Core.Models.Domain;

public class DomainCreateDto
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no debe superar los 500 caracteres.")]
    public string? Description { get; set; }

    [StringLength(100, ErrorMessage = "El tipo no debe superar los 100 caracteres.")]
    public string? Type { get; set; }

    public List<int>? LocationIds { get; set; } = new List<int>();

    public List<int>? CharacterIds { get; set; } = new List<int>();

    public List<int>? FactionIds { get; set; } = new List<int>();

    [StringLength(1000, ErrorMessage = "La historia no debe superar los 1000 caracteres.")]
    public string? History { get; set; }

    [StringLength(500, ErrorMessage = "Los objetivos no deben superar los 500 caracteres.")]
    public string? Objectives { get; set; }

    [Required]
    public int? CampaignId { get; set; }
}