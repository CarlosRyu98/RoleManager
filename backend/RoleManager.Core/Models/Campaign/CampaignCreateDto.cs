namespace RoleManager.Core.Models.Campaign;

public class CampaignCreateDto
{
    [Required(ErrorMessage = "El nombre de la campaña es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no debe superar los 500 caracteres.")]
    public string? Description { get; set; }

    [StringLength(500, ErrorMessage = "La historia no debe superar los 500 caracteres.")]
    public string? History { get; set; }

    // No incluir las listas de IDs en el DTO de creación, solo los datos relevantes
}