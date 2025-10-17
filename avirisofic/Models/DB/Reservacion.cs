namespace avirisofic.Models.DB;

public partial class Reservacion
{
    public int IdReservacion { get; set; }

    public int IdReserva { get; set; }

    public int IdRuta { get; set; }

    public int? IdGuia { get; set; }

    public DateOnly FechaReserva { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string ClienteNombre { get; set; } = null!;

    public string? ClienteCorreo { get; set; }

    public int CantAdultos { get; set; }

    public int CantNinos { get; set; }

    public int? TotalPersonas { get; set; }

    public decimal CostoTotal { get; set; }

    public string Estado { get; set; } = null!;

    public string? Notas { get; set; }

    public int CreadoPor { get; set; }

    public virtual Usuario CreadoPorNavigation { get; set; } = null!;

    public virtual GuiaTuristico? IdGuiaNavigation { get; set; }

    public virtual ReservaNatural IdReservaNavigation { get; set; } = null!;

    public virtual RutaTuristica IdRutaNavigation { get; set; } = null!;
}
