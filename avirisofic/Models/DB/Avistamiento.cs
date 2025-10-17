namespace avirisofic.Models.DB;

public partial class Avistamiento
{
    public int AvistamientoId { get; set; }

    public int EspecieId { get; set; }

    public int? LugarId { get; set; }

    public DateTime FechaHora { get; set; }

    public int? Cantidad { get; set; }

    public string? Observador { get; set; }

    public string? Notas { get; set; }

    public virtual Especie Especie { get; set; } = null!;

    public virtual ObservacionLugar? Lugar { get; set; }
}
