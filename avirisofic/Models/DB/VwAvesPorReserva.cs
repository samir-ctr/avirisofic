using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class VwAvesPorReserva
{
    public string Reserva { get; set; } = null!;

    public string Ave { get; set; } = null!;

    public string? NombreCientifico { get; set; }

    public string TipoMigracion { get; set; } = null!;

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public string? Notas { get; set; }
}
