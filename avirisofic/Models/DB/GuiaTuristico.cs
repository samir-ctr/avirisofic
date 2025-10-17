namespace avirisofic.Models.DB;

public partial class GuiaTuristico
{
    public int IdGuia { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Idiomas { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<GuiaRutum> GuiaRuta { get; set; } = new List<GuiaRutum>();

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();
}
