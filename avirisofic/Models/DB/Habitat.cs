using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class Habitat
{
    public int HabitatId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<EspecieHabitat> EspecieHabitats { get; set; } = new List<EspecieHabitat>();
}
