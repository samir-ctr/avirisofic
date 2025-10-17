namespace avirisofic.Models.DB;

public partial class Ave
{
    public int IdAve { get; set; }

    public string NombreComun { get; set; } = null!;

    public string? NombreCientifico { get; set; }

    public int IdTipoAve { get; set; }

    public string? Descripcion { get; set; }

    public int CreadoPor { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Usuario CreadoPorNavigation { get; set; } = null!;

    public virtual TipoAve IdTipoAveNavigation { get; set; } = null!;

    public virtual ICollection<MigracionAve> MigracionAves { get; set; } = new List<MigracionAve>();
}
