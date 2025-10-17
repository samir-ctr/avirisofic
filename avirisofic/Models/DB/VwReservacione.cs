namespace avirisofic.Models.DB;

public partial class VwReservacione
{
    public int IdReservacion { get; set; }

    public string ClienteNombre { get; set; } = null!;

    public string? ClienteCorreo { get; set; }

    public DateOnly FechaReserva { get; set; }

    public int CantAdultos { get; set; }

    public int CantNinos { get; set; }

    public decimal CostoTotal { get; set; }

    public string Estado { get; set; } = null!;

    public string Reserva { get; set; } = null!;

    public string Ruta { get; set; } = null!;

    public string? Guia { get; set; }
}
