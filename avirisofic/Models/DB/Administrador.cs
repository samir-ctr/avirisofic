using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class Administrador
{
    public int AdministradorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
