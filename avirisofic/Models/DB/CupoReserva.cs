namespace avirisofic.Models.DB;

public partial class CupoReserva
{
    public int IdCupoReserva { get; set; }

    public int IdReserva { get; set; }

    public DateOnly Fecha { get; set; }

    public int CupoTotal { get; set; }

    public int CupoDisponible { get; set; }

    public decimal CostoAdulto { get; set; }

    public decimal CostoNino { get; set; }

    public virtual ReservaNatural IdReservaNavigation { get; set; } = null!;

    public virtual ICollection<LogCupo> LogCupos { get; set; } = new List<LogCupo>();
}
