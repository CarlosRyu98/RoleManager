namespace RoleManager.Core.Entities;

public class Faction
{
    [Key]
    public int FactionId { get; set; }

    [Required(ErrorMessage = "El nombre de la facción es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no debe superar los 500 caracteres.")]
    public string? Description { get; set; }

    [StringLength(50, ErrorMessage = "El tipo no debe superar los 50 caracteres.")]
    public string? Type { get; set; }

    public int? LeaderId { get; set; } // Referencia al personaje líder
    public virtual Character? Leader { get; set; } // Navegación opcional a un personaje líder

    public virtual ICollection<Character>? Members { get; set; } // Navegación a personajes miembros

    public string? Base { get; set; }

    [StringLength(1000, ErrorMessage = "La historia no debe superar los 1000 caracteres.")]
    public string? History { get; set; }

    [StringLength(500, ErrorMessage = "Los objetivos no deben superar los 500 caracteres.")]
    public string? Objectives { get; set; }

    public virtual ICollection<Faction>? Allies { get; set; } // Navegación a facciones aliadas
    public virtual ICollection<Faction>? Enemies { get; set; } // Navegación a facciones enemigas
}