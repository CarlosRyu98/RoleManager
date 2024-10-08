﻿namespace RoleManager.Core.Entities;

public class QuestStage
{
    [Key]
    public int StageId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no debe superar los 500 caracteres.")]
    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    public int QuestId { get; set; }
}