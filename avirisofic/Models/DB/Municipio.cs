namespace avirisofic.Models.DB;

public partial class Municipio
{
    public int IdMunicipio { get; set; }

    public int IdDepartamento { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<ReservaNatural> ReservaNaturals { get; set; } = new List<ReservaNatural>();

    public virtual ICollection<RutaTuristica> RutaTuristicas { get; set; } = new List<RutaTuristica>();
}
