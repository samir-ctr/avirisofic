namespace avirisofic.Models.DB;

public partial class EspecieHabitat
{
    public int EspecieHabitatId { get; set; }

    public int EspecieId { get; set; }

    public int HabitatId { get; set; }

    public string? Observaciones { get; set; }

    public virtual Especie Especie { get; set; } = null!;

    public virtual Habitat Habitat { get; set; } = null!;
}
