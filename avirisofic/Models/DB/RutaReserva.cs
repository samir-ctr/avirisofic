namespace avirisofic.Models.DB;

public partial class RutaReserva
{
    public int IdRutaReserva { get; set; }

    public int IdRuta { get; set; }

    public int IdReserva { get; set; }

    public int? OrdenSecuencia { get; set; }

    public virtual ReservaNatural IdReservaNavigation { get; set; } = null!;

    public virtual RutaTuristica IdRutaNavigation { get; set; } = null!;
}
