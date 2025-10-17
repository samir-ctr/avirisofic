namespace avirisofic.Models.DB;

public partial class ObservacionLugar
{
    public int LugarId { get; set; }

    public string NombreLugar { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal? Latitud { get; set; }

    public decimal? Longitud { get; set; }

    public string? Departamento { get; set; }

    public string? Municipio { get; set; }

    public virtual ICollection<Avistamiento> Avistamientos { get; set; } = new List<Avistamiento>();
}
