namespace avirisofic.Models.DB;

public partial class Familium
{
    public int FamiliaId { get; set; }

    public string NombreFamilia { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Genero> Generos { get; set; } = new List<Genero>();
}
