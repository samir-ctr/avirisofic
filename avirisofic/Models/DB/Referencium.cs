namespace avirisofic.Models.DB;

public partial class Referencium
{
    public int ReferenciaId { get; set; }

    public int? EspecieId { get; set; }

    public string? Tipo { get; set; }

    public string TextoReferencia { get; set; } = null!;

    public string? Url { get; set; }

    public virtual Especie? Especie { get; set; }
}
