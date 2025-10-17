namespace avirisofic.Models.DB;

public partial class Genero
{
    public int GeneroId { get; set; }

    public int FamiliaId { get; set; }

    public string NombreGenero { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Especie> Especies { get; set; } = new List<Especie>();

    public virtual Familium Familia { get; set; } = null!;
}
