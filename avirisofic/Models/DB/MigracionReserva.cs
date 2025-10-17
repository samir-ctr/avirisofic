namespace avirisofic.Models.DB;

public partial class MigracionReserva
{
    public int IdMigracionReserva { get; set; }

    public int IdMigracion { get; set; }

    public int IdReserva { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public string? Notas { get; set; }

    public virtual MigracionAve IdMigracionNavigation { get; set; } = null!;

    public virtual ReservaNatural IdReservaNavigation { get; set; } = null!;
}
