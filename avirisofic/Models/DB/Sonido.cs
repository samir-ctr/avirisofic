namespace avirisofic.Models.DB;

public partial class Sonido
{
    public int SonidoId { get; set; }

    public int EspecieId { get; set; }

    public string? Url { get; set; }

    public byte[]? Archivo { get; set; }

    public string? Descripcion { get; set; }

    public string? Autor { get; set; }

    public DateTime FechaSubida { get; set; }

    public virtual Especie Especie { get; set; } = null!;
}
