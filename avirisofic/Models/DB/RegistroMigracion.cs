namespace avirisofic.Models.DB;

public partial class RegistroMigracion
{
    public int RegistroId { get; set; }

    public int EspecieId { get; set; }

    public string? TipoMigracion { get; set; }

    public string? OrigienRegion { get; set; }

    public string? DestinoRegion { get; set; }

    public int? MesInicio { get; set; }

    public int? MesFin { get; set; }

    public string? Observaciones { get; set; }

    public virtual Especie Especie { get; set; } = null!;
}
