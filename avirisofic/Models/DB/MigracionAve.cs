namespace avirisofic.Models.DB;

public partial class MigracionAve
{
    public int IdMigracion { get; set; }

    public int IdAve { get; set; }

    public int IdTipoMigracion { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public string? Notas { get; set; }

    public string? RutaMigracion { get; set; }

    public int CreadoPor { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Usuario CreadoPorNavigation { get; set; } = null!;

    public virtual Ave IdAveNavigation { get; set; } = null!;

    public virtual TipoMigracion IdTipoMigracionNavigation { get; set; } = null!;

    public virtual ICollection<MigracionReserva> MigracionReservas { get; set; } = new List<MigracionReserva>();
}
