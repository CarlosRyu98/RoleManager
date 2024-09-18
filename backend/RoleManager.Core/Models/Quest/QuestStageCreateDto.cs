namespace RoleManager.Core.Models.Quest;

public class QuestStageCreateDto
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no debe superar los 500 caracteres.")]
    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    [Required]
    public int QuestId { get; set; } // ID de la misión a la que pertenece
}