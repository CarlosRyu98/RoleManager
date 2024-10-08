﻿namespace RoleManager.Core.Models.Faction;

public class FactionUpdateDto
{
    [Required]
    public int FactionId { get; set; }

    [Required(ErrorMessage = "El nombre de la facción es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no debe superar los 500 caracteres.")]
    public string? Description { get; set; }

    [StringLength(50, ErrorMessage = "El tipo no debe superar los 50 caracteres.")]
    public string? Type { get; set; }

    public int? LeaderId { get; set; } // Referencia al personaje líder

    public string? Base { get; set; }

    [StringLength(1000, ErrorMessage = "La historia no debe superar los 1000 caracteres.")]
    public string? History { get; set; }

    [StringLength(500, ErrorMessage = "Los objetivos no deben superar los 500 caracteres.")]
    public string? Objectives { get; set; }
}