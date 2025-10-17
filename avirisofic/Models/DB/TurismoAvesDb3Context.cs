using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace avirisofic.Models.DB;

public partial class TurismoAvesDb3Context : DbContext
{
    public TurismoAvesDb3Context()
    {
    }

    public TurismoAvesDb3Context(DbContextOptions<TurismoAvesDb3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminReservaNatural> AdminReservaNaturals { get; set; }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Administradore> Administradores { get; set; }

    public virtual DbSet<Ave> Aves { get; set; }

    public virtual DbSet<Avistamiento> Avistamientos { get; set; }

    public virtual DbSet<Catalogoave> Catalogoaves { get; set; }

    public virtual DbSet<CupoReserva> CupoReservas { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Especie> Especies { get; set; }

    public virtual DbSet<EspecieHabitat> EspecieHabitats { get; set; }

    public virtual DbSet<EspecieTag> EspecieTags { get; set; }

    public virtual DbSet<Familium> Familia { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<GuiaRutum> GuiaRuta { get; set; }

    public virtual DbSet<GuiaTuristico> GuiaTuristicos { get; set; }

    public virtual DbSet<GuiasTuristico> GuiasTuristicos { get; set; }

    public virtual DbSet<GuiasTuristico1> GuiasTuristicos1 { get; set; }

    public virtual DbSet<GuiasTuristicosinfo> GuiasTuristicosinfos { get; set; }

    public virtual DbSet<Habitat> Habitats { get; set; }

    public virtual DbSet<Imagen> Imagens { get; set; }

    public virtual DbSet<LogCupo> LogCupos { get; set; }

    public virtual DbSet<MigracionAve> MigracionAves { get; set; }

    public virtual DbSet<MigracionReserva> MigracionReservas { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<ObservacionLugar> ObservacionLugars { get; set; }

    public virtual DbSet<Referencium> Referencia { get; set; }

    public virtual DbSet<RegistroMigracion> RegistroMigracions { get; set; }

    public virtual DbSet<ReservaNatural> ReservaNaturals { get; set; }

    public virtual DbSet<Reservacion> Reservacions { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RutaReserva> RutaReservas { get; set; }

    public virtual DbSet<RutaTuristica> RutaTuristicas { get; set; }

    public virtual DbSet<Sonido> Sonidos { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TipoAve> TipoAves { get; set; }

    public virtual DbSet<TipoMigracion> TipoMigracions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    public virtual DbSet<VwAvesPorReserva> VwAvesPorReservas { get; set; }

    public virtual DbSet<VwDisponibilidad> VwDisponibilidads { get; set; }

    public virtual DbSet<VwReservacione> VwReservaciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JOSE\\LOCALHOST; Database=TurismoAvesDB3; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminReservaNatural>(entity =>
        {
            entity.HasKey(e => e.ReservaNaturalId).HasName("PK__adminRes__C8D160D00F832CB6");

            entity.ToTable("adminReservaNatural");

            entity.Property(e => e.ReservaNaturalId).HasColumnName("ReservaNaturalID");
            entity.Property(e => e.Coordenadas).HasMaxLength(100);
            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Localidad).HasMaxLength(150);
            entity.Property(e => e.Municipio).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.UbicacionTexto).HasMaxLength(300);
        });

        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.AdministradorId).HasName("PK__Administ__2C780D566B70951D");

            entity.ToTable("Administrador");

            entity.Property(e => e.AdministradorId).HasColumnName("AdministradorID");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(30);
        });

        modelBuilder.Entity<Administradore>(entity =>
        {
            entity.HasKey(e => e.AdministradorId).HasName("PK__Administ__2C780D56376A9C0A");

            entity.Property(e => e.AdministradorId).HasColumnName("AdministradorID");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(30);
        });

        modelBuilder.Entity<Ave>(entity =>
        {
            entity.HasKey(e => e.IdAve).HasName("PK__Ave__0E2B3FF352A221EE");

            entity.ToTable("Ave");

            entity.Property(e => e.CreadoPor).HasDefaultValue(1);
            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCientifico).HasMaxLength(150);
            entity.Property(e => e.NombreComun).HasMaxLength(150);

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.Aves)
                .HasForeignKey(d => d.CreadoPor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ave_Usuario");

            entity.HasOne(d => d.IdTipoAveNavigation).WithMany(p => p.Aves)
                .HasForeignKey(d => d.IdTipoAve)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ave_TipoAve");
        });

        modelBuilder.Entity<Avistamiento>(entity =>
        {
            entity.HasKey(e => e.AvistamientoId).HasName("PK__Avistami__958C1A37A7FA7807");

            entity.ToTable("Avistamiento");

            entity.Property(e => e.AvistamientoId).HasColumnName("AvistamientoID");
            entity.Property(e => e.EspecieId).HasColumnName("EspecieID");
            entity.Property(e => e.LugarId).HasColumnName("LugarID");
            entity.Property(e => e.Notas).HasMaxLength(1000);
            entity.Property(e => e.Observador).HasMaxLength(200);

            entity.HasOne(d => d.Especie).WithMany(p => p.Avistamientos)
                .HasForeignKey(d => d.EspecieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Av_Especie");

            entity.HasOne(d => d.Lugar).WithMany(p => p.Avistamientos)
                .HasForeignKey(d => d.LugarId)
                .HasConstraintName("FK_Av_Lugar");
        });

        modelBuilder.Entity<Catalogoave>(entity =>
        {
            entity.HasKey(e => e.Aveid).HasName("PK__catalogo__C275690DA6F17DBA");

            entity.ToTable("catalogoave");

            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .HasColumnName("genero");
        });

        modelBuilder.Entity<CupoReserva>(entity =>
        {
            entity.HasKey(e => e.IdCupoReserva).HasName("PK__CupoRese__617DF92860B4AD3E");

            entity.ToTable("CupoReserva");

            entity.HasIndex(e => new { e.IdReserva, e.Fecha }, "UQ_CupoReserva").IsUnique();

            entity.Property(e => e.CostoAdulto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CostoNino).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.CupoReservas)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CupoReserva_Reserva");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433DC5B5AF8D");

            entity.ToTable("Departamento");

            entity.HasIndex(e => e.Nombre, "UQ__Departam__75E3EFCFDEB2D46A").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Especie>(entity =>
        {
            entity.HasKey(e => e.EspecieId).HasName("PK__Especie__9CF6045C1F9C5F88");

            entity.ToTable("Especie");

            entity.HasIndex(e => e.NombreCientifico, "UQ_Especie_NombreCientifico").IsUnique();

            entity.Property(e => e.EspecieId).HasColumnName("EspecieID");
            entity.Property(e => e.EstacionMigratoria).HasMaxLength(200);
            entity.Property(e => e.EstadoConservacion).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.GeneroId).HasColumnName("GeneroID");
            entity.Property(e => e.NombreCientifico).HasMaxLength(300);
            entity.Property(e => e.NombreComun).HasMaxLength(200);
            entity.Property(e => e.PesoPromedioG).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.TamañoPromedioCm)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("TamañoPromedioCM");

            entity.HasOne(d => d.Genero).WithMany(p => p.Especies)
                .HasForeignKey(d => d.GeneroId)
                .HasConstraintName("FK_Especie_Genero");
        });

        modelBuilder.Entity<EspecieHabitat>(entity =>
        {
            entity.HasKey(e => e.EspecieHabitatId).HasName("PK__EspecieH__976A0ABF56F28996");

            entity.ToTable("EspecieHabitat");

            entity.HasIndex(e => new { e.EspecieId, e.HabitatId }, "UQ_EH").IsUnique();

            entity.Property(e => e.EspecieHabitatId).HasColumnName("EspecieHabitatID");
            entity.Property(e => e.EspecieId).HasColumnName("EspecieID");
            entity.Property(e => e.HabitatId).HasColumnName("HabitatID");
            entity.Property(e => e.Observaciones).HasMaxLength(500);

            entity.HasOne(d => d.Especie).WithMany(p => p.EspecieHabitats)
                .HasForeignKey(d => d.EspecieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EH_Especie");

            entity.HasOne(d => d.Habitat).WithMany(p => p.EspecieHabitats)
                .HasForeignKey(d => d.HabitatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EH_Habitat");
        });

        modelBuilder.Entity<EspecieTag>(entity =>
        {
            entity.HasKey(e => e.EspecieTagId).HasName("PK__EspecieT__33E707D55FE25D73");

            entity.ToTable("EspecieTag");

            entity.HasIndex(e => new { e.EspecieId, e.TagId }, "UQ_ET").IsUnique();

            entity.Property(e => e.EspecieTagId).HasColumnName("EspecieTagID");
            entity.Property(e => e.EspecieId).HasColumnName("EspecieID");
            entity.Property(e => e.TagId).HasColumnName("TagID");

            entity.HasOne(d => d.Especie).WithMany(p => p.EspecieTags)
                .HasForeignKey(d => d.EspecieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ET_Especie");

            entity.HasOne(d => d.Tag).WithMany(p => p.EspecieTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ET_Tag");
        });

        modelBuilder.Entity<Familium>(entity =>
        {
            entity.HasKey(e => e.FamiliaId).HasName("PK__Familia__42DFCCE4A622D439");

            entity.HasIndex(e => e.NombreFamilia, "UQ__Familia__1A1600E4A25A0565").IsUnique();

            entity.Property(e => e.FamiliaId).HasColumnName("FamiliaID");
            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.NombreFamilia).HasMaxLength(200);
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.GeneroId).HasName("PK__Genero__A99D026883901E02");

            entity.ToTable("Genero");

            entity.HasIndex(e => new { e.FamiliaId, e.NombreGenero }, "UQ__Genero__29B3D0D77DE0C7F8").IsUnique();

            entity.Property(e => e.GeneroId).HasColumnName("GeneroID");
            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.FamiliaId).HasColumnName("FamiliaID");
            entity.Property(e => e.NombreGenero).HasMaxLength(200);

            entity.HasOne(d => d.Familia).WithMany(p => p.Generos)
                .HasForeignKey(d => d.FamiliaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Genero_Familia");
        });

        modelBuilder.Entity<GuiaRutum>(entity =>
        {
            entity.HasKey(e => e.IdGuiaRuta).HasName("PK__GuiaRuta__458F8C10EA2FE3FF");

            entity.HasOne(d => d.IdGuiaNavigation).WithMany(p => p.GuiaRuta)
                .HasForeignKey(d => d.IdGuia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GuiaRuta_Guia");

            entity.HasOne(d => d.IdRutaNavigation).WithMany(p => p.GuiaRuta)
                .HasForeignKey(d => d.IdRuta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GuiaRuta_Ruta");
        });

        modelBuilder.Entity<GuiaTuristico>(entity =>
        {
            entity.HasKey(e => e.IdGuia).HasName("PK__GuiaTuri__838CF14015A5B023");

            entity.ToTable("GuiaTuristico");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(150);
            entity.Property(e => e.Idiomas).HasMaxLength(250);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        modelBuilder.Entity<GuiasTuristico>(entity =>
        {
            entity.HasKey(e => e.GuiaId).HasName("PK__GuiasTur__4A40D8E5BD8A564A");

            entity.ToTable("GuiasTuristico");

            entity.Property(e => e.GuiaId).HasColumnName("GuiaID");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Especialidad).HasMaxLength(150);
            entity.Property(e => e.InfoProfesional).HasMaxLength(500);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(30);
        });

        modelBuilder.Entity<GuiasTuristico1>(entity =>
        {
            entity.HasKey(e => e.GuiaId).HasName("PK__GuiasTur__4A40D8E5C584BA1C");

            entity.ToTable("GuiasTuristicos");

            entity.Property(e => e.GuiaId).HasColumnName("GuiaID");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Especialidad).HasMaxLength(150);
            entity.Property(e => e.InfoProfesional).HasMaxLength(500);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(30);
        });

        modelBuilder.Entity<GuiasTuristicosinfo>(entity =>
        {
            entity.HasKey(e => e.GuiaId).HasName("PK__GuiasTur__4A40D8E5248814B9");

            entity.ToTable("GuiasTuristicosinfo");

            entity.Property(e => e.GuiaId).HasColumnName("GuiaID");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Especialidad).HasMaxLength(150);
            entity.Property(e => e.InfoProfesional).HasMaxLength(500);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(30);
        });

        modelBuilder.Entity<Habitat>(entity =>
        {
            entity.HasKey(e => e.HabitatId).HasName("PK__Habitat__8392B79B4A5917D3");

            entity.ToTable("Habitat");

            entity.HasIndex(e => e.Nombre, "UQ__Habitat__75E3EFCF13A63170").IsUnique();

            entity.Property(e => e.HabitatId).HasColumnName("HabitatID");
            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.Nombre).HasMaxLength(150);
        });

        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.HasKey(e => e.ImagenId).HasName("PK__Imagen__0C7D20D7A6F11342");

            entity.ToTable("Imagen");

            entity.Property(e => e.ImagenId).HasColumnName("ImagenID");
            entity.Property(e => e.Autor).HasMaxLength(200);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.EspecieId).HasColumnName("EspecieID");
            entity.Property(e => e.FechaSubida).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Url).HasMaxLength(1000);

            entity.HasOne(d => d.Especie).WithMany(p => p.Imagens)
                .HasForeignKey(d => d.EspecieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Imagen_Especie");
        });

        modelBuilder.Entity<LogCupo>(entity =>
        {
            entity.HasKey(e => e.IdLog).HasName("PK__LogCupo__0C54DBC63BFFE1E8");

            entity.ToTable("LogCupo");

            entity.Property(e => e.FechaCambio).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Notas).HasMaxLength(500);
            entity.Property(e => e.TipoCambio).HasMaxLength(50);

            entity.HasOne(d => d.IdCupoReservaNavigation).WithMany(p => p.LogCupos)
                .HasForeignKey(d => d.IdCupoReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogCupo");
        });

        modelBuilder.Entity<MigracionAve>(entity =>
        {
            entity.HasKey(e => e.IdMigracion).HasName("PK__Migracio__A9D27AF5B2A0E219");

            entity.ToTable("MigracionAve");

            entity.Property(e => e.CreadoPor).HasDefaultValue(1);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Notas).HasMaxLength(1000);
            entity.Property(e => e.RutaMigracion).HasMaxLength(1000);

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.MigracionAves)
                .HasForeignKey(d => d.CreadoPor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MigracionAve_Usuario");

            entity.HasOne(d => d.IdAveNavigation).WithMany(p => p.MigracionAves)
                .HasForeignKey(d => d.IdAve)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Migracion_Ave");

            entity.HasOne(d => d.IdTipoMigracionNavigation).WithMany(p => p.MigracionAves)
                .HasForeignKey(d => d.IdTipoMigracion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Migracion_Tipo");
        });

        modelBuilder.Entity<MigracionReserva>(entity =>
        {
            entity.HasKey(e => e.IdMigracionReserva).HasName("PK__Migracio__8D9844D96CDB0892");

            entity.ToTable("MigracionReserva");

            entity.HasIndex(e => new { e.IdMigracion, e.IdReserva }, "UQ_MigracionReserva").IsUnique();

            entity.Property(e => e.Notas).HasMaxLength(500);

            entity.HasOne(d => d.IdMigracionNavigation).WithMany(p => p.MigracionReservas)
                .HasForeignKey(d => d.IdMigracion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MigracionReserva_Migracion");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.MigracionReservas)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MigracionReserva_Reserva");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__Municipi__61005978A7395A31");

            entity.ToTable("Municipio");

            entity.HasIndex(e => new { e.IdDepartamento, e.Nombre }, "UQ_Municipio").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Municipio_Departamento");
        });

        modelBuilder.Entity<ObservacionLugar>(entity =>
        {
            entity.HasKey(e => e.LugarId).HasName("PK__Observac__1BDE0D806AE9927C");

            entity.ToTable("ObservacionLugar");

            entity.Property(e => e.LugarId).HasColumnName("LugarID");
            entity.Property(e => e.Departamento).HasMaxLength(150);
            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.Latitud).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitud).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Municipio).HasMaxLength(150);
            entity.Property(e => e.NombreLugar).HasMaxLength(250);
        });

        modelBuilder.Entity<Referencium>(entity =>
        {
            entity.HasKey(e => e.ReferenciaId).HasName("PK__Referenc__9907D86392C28902");

            entity.Property(e => e.ReferenciaId).HasColumnName("ReferenciaID");
            entity.Property(e => e.EspecieId).HasColumnName("EspecieID");
            entity.Property(e => e.TextoReferencia).HasMaxLength(2000);
            entity.Property(e => e.Tipo).HasMaxLength(100);
            entity.Property(e => e.Url).HasMaxLength(1000);

            entity.HasOne(d => d.Especie).WithMany(p => p.Referencia)
                .HasForeignKey(d => d.EspecieId)
                .HasConstraintName("FK_Ref_Especie");
        });

        modelBuilder.Entity<RegistroMigracion>(entity =>
        {
            entity.HasKey(e => e.RegistroId).HasName("PK__Registro__B897313E9791420B");

            entity.ToTable("RegistroMigracion");

            entity.Property(e => e.RegistroId).HasColumnName("RegistroID");
            entity.Property(e => e.DestinoRegion).HasMaxLength(200);
            entity.Property(e => e.EspecieId).HasColumnName("EspecieID");
            entity.Property(e => e.Observaciones).HasMaxLength(1000);
            entity.Property(e => e.OrigienRegion).HasMaxLength(200);
            entity.Property(e => e.TipoMigracion).HasMaxLength(100);

            entity.HasOne(d => d.Especie).WithMany(p => p.RegistroMigracions)
                .HasForeignKey(d => d.EspecieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegMig_Especie");
        });

        modelBuilder.Entity<ReservaNatural>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__ReservaN__0E49C69D33558B23");

            entity.ToTable("ReservaNatural");

            entity.Property(e => e.Activa).HasDefaultValue(true);
            entity.Property(e => e.CreadoPor).HasDefaultValue(1);
            entity.Property(e => e.CupoDiarioDefault).HasDefaultValue(20);
            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImagenRef).HasMaxLength(250);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Ubicacion).HasMaxLength(250);

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.ReservaNaturals)
                .HasForeignKey(d => d.CreadoPor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaNatural_Usuario");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.ReservaNaturals)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK_ReservaNatural_Municipio");
        });

        modelBuilder.Entity<Reservacion>(entity =>
        {
            entity.HasKey(e => e.IdReservacion).HasName("PK__Reservac__5282463781AF881A");

            entity.ToTable("Reservacion");

            entity.Property(e => e.ClienteCorreo).HasMaxLength(150);
            entity.Property(e => e.ClienteNombre).HasMaxLength(200);
            entity.Property(e => e.CostoTotal).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.CreadoPor).HasDefaultValue(1);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("CONFIRMADA");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Notas).HasMaxLength(1000);
            entity.Property(e => e.TotalPersonas).HasComputedColumnSql("([CantAdultos]+[CantNinos])", true);

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.CreadoPor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservacion_Usuario");

            entity.HasOne(d => d.IdGuiaNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.IdGuia)
                .HasConstraintName("FK_Reservacion_Guia");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservacion_Reserva");

            entity.HasOne(d => d.IdRutaNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.IdRuta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservacion_Ruta");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584C7F669A87");

            entity.ToTable("Rol");

            entity.HasIndex(e => e.Nombre, "UQ__Rol__75E3EFCFA637C298").IsUnique();

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<RutaReserva>(entity =>
        {
            entity.HasKey(e => e.IdRutaReserva).HasName("PK__RutaRese__D15981D581FE31AA");

            entity.ToTable("RutaReserva");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.RutaReservas)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RutaReserva_Reserva");

            entity.HasOne(d => d.IdRutaNavigation).WithMany(p => p.RutaReservas)
                .HasForeignKey(d => d.IdRuta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RutaReserva_Ruta");
        });

        modelBuilder.Entity<RutaTuristica>(entity =>
        {
            entity.HasKey(e => e.IdRuta).HasName("PK__RutaTuri__887538FE372B78EA");

            entity.ToTable("RutaTuristica");

            entity.Property(e => e.Activa).HasDefaultValue(true);
            entity.Property(e => e.CreadoPor).HasDefaultValue(1);
            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.Dificultad).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(200);

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.RutaTuristicas)
                .HasForeignKey(d => d.CreadoPor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RutaTuristica_Usuario");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.RutaTuristicas)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK_RutaTuristica_Municipio");
        });

        modelBuilder.Entity<Sonido>(entity =>
        {
            entity.HasKey(e => e.SonidoId).HasName("PK__Sonido__FAF1682151FD648E");

            entity.ToTable("Sonido");

            entity.Property(e => e.SonidoId).HasColumnName("SonidoID");
            entity.Property(e => e.Autor).HasMaxLength(200);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.EspecieId).HasColumnName("EspecieID");
            entity.Property(e => e.FechaSubida).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Url).HasMaxLength(1000);

            entity.HasOne(d => d.Especie).WithMany(p => p.Sonidos)
                .HasForeignKey(d => d.EspecieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sonido_Especie");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Tag__657CFA4CF029FC0F");

            entity.ToTable("Tag");

            entity.HasIndex(e => e.Nombre, "UQ_Tag_Nombre").IsUnique();

            entity.Property(e => e.TagId).HasColumnName("TagID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<TipoAve>(entity =>
        {
            entity.HasKey(e => e.IdTipoAve).HasName("PK__TipoAve__0F4FACCCFFCD5C91");

            entity.ToTable("TipoAve");

            entity.Property(e => e.Descripcion).HasMaxLength(400);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<TipoMigracion>(entity =>
        {
            entity.HasKey(e => e.IdTipoMigracion).HasName("PK__TipoMigr__E453720BFE4D8A58");

            entity.ToTable("TipoMigracion");

            entity.Property(e => e.Descripcion).HasMaxLength(400);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97D5CB45BD");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534ABF6063D").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioRol).HasName("PK__UsuarioR__6806BF4ACB84A8AE");

            entity.ToTable("UsuarioRol");

            entity.HasIndex(e => new { e.IdUsuario, e.IdRol }, "UQ_UsuarioRol").IsUnique();

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRol_Rol");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRol_Usuario");
        });

        modelBuilder.Entity<VwAvesPorReserva>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AvesPorReserva");

            entity.Property(e => e.Ave).HasMaxLength(150);
            entity.Property(e => e.NombreCientifico).HasMaxLength(150);
            entity.Property(e => e.Notas).HasMaxLength(500);
            entity.Property(e => e.Reserva).HasMaxLength(200);
            entity.Property(e => e.TipoMigracion).HasMaxLength(100);
        });

        modelBuilder.Entity<VwDisponibilidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Disponibilidad");

            entity.Property(e => e.CostoAdulto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CostoNino).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Reserva).HasMaxLength(200);
        });

        modelBuilder.Entity<VwReservacione>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Reservaciones");

            entity.Property(e => e.ClienteCorreo).HasMaxLength(150);
            entity.Property(e => e.ClienteNombre).HasMaxLength(200);
            entity.Property(e => e.CostoTotal).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Guia).HasMaxLength(201);
            entity.Property(e => e.Reserva).HasMaxLength(200);
            entity.Property(e => e.Ruta).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
