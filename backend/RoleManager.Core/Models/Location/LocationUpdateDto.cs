﻿namespace RoleManager.Core.Models.Location;

public class LocationUpdateDto
{
    [Required]
    public int LocationId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no debe superar los 500 caracteres.")]
    public string? Description { get; set; }

    public int? DomainId { get; set; } // ID del dominio al que pertenece

    public List<int>? CharacterIds { get; set; } = new List<int>();

    [Required]
    public int? CampaignId { get; set; }
}