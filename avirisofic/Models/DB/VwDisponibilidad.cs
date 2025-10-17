using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class VwDisponibilidad
{
    public string Reserva { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public int CupoTotal { get; set; }

    public int CupoDisponible { get; set; }

    public decimal CostoAdulto { get; set; }

    public decimal CostoNino { get; set; }
}
