namespace RoleManager.Models;

public class CharacterEpic: Character
{
    [Range(1, 20, ErrorMessage = "Strength debe estar entre 1 y 20.")]
    public int? Strength { get; set; }

    [Range(1, 20, ErrorMessage = "Dexterity debe estar entre 1 y 20.")]
    public int? Dexterity { get; set; }

    [Range(1, 20, ErrorMessage = "Constitution debe estar entre 1 y 20.")]
    public int? Constitution { get; set; }

    [Range(1, 20, ErrorMessage = "Intelligence debe estar entre 1 y 20.")]
    public int? Intelligence { get; set; }

    [Range(1, 20, ErrorMessage = "Wisdom debe estar entre 1 y 20.")]
    public int? Wisdom { get; set; }

    [Range(1, 20, ErrorMessage = "Charisma debe estar entre 1 y 20.")]
    public int? Charisma { get; set; }

    [Range(0, 500, ErrorMessage = "HitPoints debe estar entre 0 y 500.")]
    public int? HitPoints { get; set; }

    [Range(0, 50, ErrorMessage = "ArmorClass debe estar entre 0 y 50.")]
    public int? ArmorClass { get; set; }
}
