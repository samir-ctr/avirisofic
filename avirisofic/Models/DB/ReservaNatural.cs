namespace avirisofic.Models.DB;

public partial class ReservaNatural
{
    public int IdReserva { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Ubicacion { get; set; }

    public int CupoDiarioDefault { get; set; }

    public bool Activa { get; set; }

    public int? IdMunicipio { get; set; }

    public int CreadoPor { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? ImagenRef { get; set; }

    public virtual Usuario CreadoPorNavigation { get; set; } = null!;

    public virtual ICollection<CupoReserva> CupoReservas { get; set; } = new List<CupoReserva>();

    public virtual Municipio? IdMunicipioNavigation { get; set; }

    public virtual ICollection<MigracionReserva> MigracionReservas { get; set; } = new List<MigracionReserva>();

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();

    public virtual ICollection<RutaReserva> RutaReservas { get; set; } = new List<RutaReserva>();
}
