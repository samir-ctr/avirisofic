namespace avirisofic.Models.DB;

public partial class EspecieTag
{
    public int EspecieTagId { get; set; }

    public int EspecieId { get; set; }

    public int TagId { get; set; }

    public virtual Especie Especie { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
