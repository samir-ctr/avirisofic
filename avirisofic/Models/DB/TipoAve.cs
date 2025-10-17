using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class TipoAve
{
    public int IdTipoAve { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Ave> Aves { get; set; } = new List<Ave>();
}
