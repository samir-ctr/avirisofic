using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class LogCupo
{
    public int IdLog { get; set; }

    public int IdCupoReserva { get; set; }

    public DateTime FechaCambio { get; set; }

    public string TipoCambio { get; set; } = null!;

    public int Variacion { get; set; }

    public string? Notas { get; set; }

    public virtual CupoReserva IdCupoReservaNavigation { get; set; } = null!;
}
