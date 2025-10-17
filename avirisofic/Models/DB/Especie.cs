using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class Especie
{
    public int EspecieId { get; set; }

    public int? GeneroId { get; set; }

    public string NombreComun { get; set; } = null!;

    public string NombreCientifico { get; set; } = null!;

    public string? EstadoConservacion { get; set; }

    public decimal? TamañoPromedioCm { get; set; }

    public decimal? PesoPromedioG { get; set; }

    public string? Descripcion { get; set; }

    public bool Migratoria { get; set; }

    public string? EstacionMigratoria { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Avistamiento> Avistamientos { get; set; } = new List<Avistamiento>();

    public virtual ICollection<EspecieHabitat> EspecieHabitats { get; set; } = new List<EspecieHabitat>();

    public virtual ICollection<EspecieTag> EspecieTags { get; set; } = new List<EspecieTag>();

    public virtual Genero? Genero { get; set; }

    public virtual ICollection<Imagen> Imagens { get; set; } = new List<Imagen>();

    public virtual ICollection<Referencium> Referencia { get; set; } = new List<Referencium>();

    public virtual ICollection<RegistroMigracion> RegistroMigracions { get; set; } = new List<RegistroMigracion>();

    public virtual ICollection<Sonido> Sonidos { get; set; } = new List<Sonido>();
}
