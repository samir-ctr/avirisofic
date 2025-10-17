using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class AdminReservaNatural
{
    public int ReservaNaturalId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Municipio { get; set; }

    public string? Localidad { get; set; }

    public string? UbicacionTexto { get; set; }

    public string? Coordenadas { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
