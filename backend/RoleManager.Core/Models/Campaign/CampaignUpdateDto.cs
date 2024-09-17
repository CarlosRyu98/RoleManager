namespace RoleManager.Core.Models.Campaign;

public class CampaignUpdateDto
{
    [Required]
    public int CampaignId { get; set; }  // Necesario para identificar qué campaña actualizar

    [Required(ErrorMessage = "El nombre de la campaña es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no debe superar los 500 caracteres.")]
    public string? Description { get; set; }

    [StringLength(500, ErrorMessage = "La historia no debe superar los 500 caracteres.")]
    public string? History { get; set; }

    // Incluye solo las propiedades que se pueden actualizar
}
