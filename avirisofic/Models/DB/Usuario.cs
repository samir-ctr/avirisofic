using System;
using System.Collections.Generic;

namespace avirisofic.Models.DB;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Ave> Aves { get; set; } = new List<Ave>();

    public virtual ICollection<MigracionAve> MigracionAves { get; set; } = new List<MigracionAve>();

    public virtual ICollection<ReservaNatural> ReservaNaturals { get; set; } = new List<ReservaNatural>();

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();

    public virtual ICollection<RutaTuristica> RutaTuristicas { get; set; } = new List<RutaTuristica>();

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
