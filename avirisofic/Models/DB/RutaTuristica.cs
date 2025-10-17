namespace avirisofic.Models.DB;

public partial class RutaTuristica
{
    public int IdRuta { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? DuracionMinutos { get; set; }

    public string? Dificultad { get; set; }

    public bool Activa { get; set; }

    public int? IdMunicipio { get; set; }

    public int CreadoPor { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Usuario CreadoPorNavigation { get; set; } = null!;

    public virtual ICollection<GuiaRutum> GuiaRuta { get; set; } = new List<GuiaRutum>();

    public virtual Municipio? IdMunicipioNavigation { get; set; }

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();

    public virtual ICollection<RutaReserva> RutaReservas { get; set; } = new List<RutaReserva>();
}
