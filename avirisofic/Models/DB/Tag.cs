using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class Tag
{
    public int TagId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<EspecieTag> EspecieTags { get; set; } = new List<EspecieTag>();
}
