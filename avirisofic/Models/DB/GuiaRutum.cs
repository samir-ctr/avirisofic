using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class GuiaRutum
{
    public int IdGuiaRuta { get; set; }

    public int IdGuia { get; set; }

    public int IdRuta { get; set; }

    public virtual GuiaTuristico IdGuiaNavigation { get; set; } = null!;

    public virtual RutaTuristica IdRutaNavigation { get; set; } = null!;
}
