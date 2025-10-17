using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class Imagen
{
    public int ImagenId { get; set; }

    public int EspecieId { get; set; }

    public string? Url { get; set; }

    public byte[]? Archivo { get; set; }

    public string? Descripcion { get; set; }

    public string? Autor { get; set; }

    public DateTime FechaSubida { get; set; }

    public bool EsPrincipal { get; set; }

    public virtual Especie Especie { get; set; } = null!;
}
