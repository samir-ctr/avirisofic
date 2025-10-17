using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class GuiasTuristico
{
    public int GuiaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Especialidad { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? InfoProfesional { get; set; }
}
