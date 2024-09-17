namespace RoleManager.Models;

public class Character
{
    [Key]
    public int CharacterId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
    public string? Name { get; set; }

    public string? Sex { get; set; }

    [StringLength(50, ErrorMessage = "La raza no debe superar los 50 caracteres.")]
    public string? Race { get; set; }

    public List<string>? Inventory { get; set; } = new List<string>();

    [MaxLength(10, ErrorMessage = "No puede tener más de 10 competencias.")]
    public List<string>? Proficiencies { get; set; } = new List<string>();

    [MaxLength(5, ErrorMessage = "No puede hablar más de 5 idiomas.")]
    public List<string>? Languages { get; set; } = new List<string>();

    [StringLength(500, ErrorMessage = "La historia no debe superar los 500 caracteres.")]
    public string? Backstory { get; set; }

    [StringLength(300, ErrorMessage = "Las motivaciones no deben superar los 300 caracteres.")]
    public string? Motivations { get; set; }

    [StringLength(200, ErrorMessage = "Los rasgos de personalidad no deben superar los 200 caracteres.")]
    public string? PersonalityTraits { get; set; }

    [StringLength(200, ErrorMessage = "La descripción física no debe superar los 200 caracteres.")]
    public string? PhysicalDescription { get; set; }

    [StringLength(200, ErrorMessage = "Las manías no deben superar los 200 caracteres.")]
    public string? Quirks { get; set; }

    public string? Status { get; set; }

    [Required]
    public int CampaignId { get; set; }

    public int? FactionId { get; set; }
    public virtual Faction? Faction { get; set; }

    public int? LocationId { get; set; }

    // Simpatías y rivalidades
    public virtual ICollection<Character>? Allies { get; set; } = new HashSet<Character>();
    public virtual ICollection<Character>? Rivals { get; set; } = new HashSet<Character>();
}
