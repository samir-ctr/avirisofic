using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class TipoMigracion
{
    public int IdTipoMigracion { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<MigracionAve> MigracionAves { get; set; } = new List<MigracionAve>();
}
