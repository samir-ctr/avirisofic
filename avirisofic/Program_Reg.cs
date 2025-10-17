using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configuración: añadir la cadena de conexión en appsettings.json o como variable de entorno:
// "ConnectionStrings": { "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BASE;User Id=TU_USUARIO;Password=TU_PASS;" }
builder.Services.Configure<JsonOptions>(opts => { opts.SerializerOptions.PropertyNameCaseInsensitive = true; });
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();
app.UseCors();
app.UseDefaultFiles(); // sirve index.html por defecto desde wwwroot
app.UseStaticFiles();

var configuration = app.Configuration;
var connStr = configuration.GetConnectionString("DefaultConnection") ?? Environment.GetEnvironmentVariable("DefaultConnection");

if (string.IsNullOrWhiteSpace(connStr))
{
    Console.WriteLine("WARNING: No se ha encontrado la cadena de conexión 'DefaultConnection'. Defínela en appsettings.json o variable de entorno 'DefaultConnection'.");
}

// Asegurarse de que la tabla Users existe
if (!string.IsNullOrWhiteSpace(connStr))
{
    EnsureUsersTable(connStr);
}

app.MapPost("/api/register", async (HttpContext http) =>
{
    var dto = await http.Request.ReadFromJsonAsync<RegisterDto>();
    if (dto == null) return Results.BadRequest(new { error = "Payload inválido" });

    if (string.IsNullOrWhiteSpace(connStr)) return Results.Problem("Cadena de conexión no configurada.");

    // Validaciones mínimas
    dto.Email = (dto.Email ?? "").Trim().ToLowerInvariant();
    dto.Username = (dto.Username ?? dto.Email.Split('@')[0]).Trim();
    if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password) || string.IsNullOrWhiteSpace(dto.Username))
        return Results.BadRequest(new { error = "Faltan campos requeridos." });

    using var conn = new SqlConnection(connStr);
    await conn.OpenAsync();

    // Comprobar si existe usuario por email o username
    var existsCmd = new SqlCommand(@"SELECT COUNT(1) FROM Users WHERE Email = @Email OR Username = @Username", conn);
    existsCmd.Parameters.AddWithValue("@Email", dto.Email);
    existsCmd.Parameters.AddWithValue("@Username", dto.Username);
    var exists = (int)await existsCmd.ExecuteScalarAsync() > 0;
    if (exists) return Results.Conflict(new { error = "Ya existe un usuario con ese correo o nombre." });

    // Hashear la contraseña
    var passwordHash = CreatePasswordHash(dto.Password);

    var insertCmd = new SqlCommand(@"
        INSERT INTO Users (Id, Nombre, Apellido, Email, Username, PasswordHash, Dob, Origen, Role)
        VALUES (NEWID(), @Nombre, @Apellido, @Email, @Username, @PasswordHash, @Dob, @Origen, @Role);", conn);
    insertCmd.Parameters.AddWithValue("@Nombre", (object?)dto.Nombre ?? DBNull.Value);
    insertCmd.Parameters.AddWithValue("@Apellido", (object?)dto.Apellido ?? DBNull.Value);
    insertCmd.Parameters.AddWithValue("@Email", dto.Email);
    insertCmd.Parameters.AddWithValue("@Username", dto.Username);
    insertCmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
    insertCmd.Parameters.AddWithValue("@Dob", (object?)dto.Dob ?? DBNull.Value);
    insertCmd.Parameters.AddWithValue("@Origen", (object?)dto.Origen ?? DBNull.Value);
    insertCmd.Parameters.AddWithValue("@Role", (object?)dto.Role ?? "usuario");

    await insertCmd.ExecuteNonQueryAsync();
    return Results.Ok(new { message = "Cuenta creada correctamente." });
});

app.MapPost("/api/login", async (HttpContext http) =>
{
    var dto = await http.Request.ReadFromJsonAsync<LoginDto>();
    if (dto == null) return Results.BadRequest(new { error = "Payload inválido" });
    if (string.IsNullOrWhiteSpace(connStr)) return Results.Problem("Cadena de conexión no configurada.");

    using var conn = new SqlConnection(connStr);
    await conn.OpenAsync();

    var cmd = new SqlCommand(@"SELECT TOP(1) PasswordHash, Username, Email, Role FROM Users WHERE Email = @Identifier OR Username = @Identifier", conn);
    cmd.Parameters.AddWithValue("@Identifier", dto.Identifier.Trim().ToLowerInvariant());
    using var reader = await cmd.ExecuteReaderAsync();
    if (!await reader.ReadAsync()) return Results.Unauthorized();

    var storedHash = reader.GetString(0);
    var username = reader.IsDBNull(1) ? null : reader.GetString(1);
    var email = reader.IsDBNull(2) ? null : reader.GetString(2);
    var role = reader.IsDBNull(3) ? null : reader.GetString(3);

    if (!VerifyPassword(storedHash, dto.Password)) return Results.Unauthorized();

    // En un sistema real generarías un JWT u otro mecanismo de sesión. Aquí devolvemos datos básicos.
    return Results.Ok(new { message = "Autenticado", username, email, role });
});

// Ejemplo: rutas y servidor listo
app.Run();


// --- DTOs ---
record RegisterDto
{
    public string? Nombre { get; init; }
    public string? Apellido { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }
    public string? Dob { get; init; } // yyyy-MM-dd
    public string? Origen { get; init; }
    public string? Role { get; init; }
    public string? Username { get; init; }
}

record LoginDto
{
    public string Identifier { get; init; } = default!;
    public string Password { get; init; } = default!;
}


// --- Helpers ---
static void EnsureUsersTable(string connStr)
{
    using var conn = new SqlConnection(connStr);
    conn.Open();
    var sql = @"
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        Nombre NVARCHAR(100) NULL,
        Apellido NVARCHAR(100) NULL,
        Email NVARCHAR(200) NOT NULL UNIQUE,
        Username NVARCHAR(100) NOT NULL UNIQUE,
        PasswordHash NVARCHAR(MAX) NOT NULL,
        Dob DATE NULL,
        Origen NVARCHAR(200) NULL,
        Role NVARCHAR(50) NULL
    );
END";
    using var cmd = new SqlCommand(sql, conn);
    cmd.ExecuteNonQuery();
}

static string CreatePasswordHash(string password)
{
    // PBKDF2 con salt de 16 bytes, 100_000 iteraciones
    using var rng = RandomNumberGenerator.Create();
    byte[] salt = new byte[16];
    rng.GetBytes(salt);

    using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
    byte[] hash = pbkdf2.GetBytes(32); // 256 bits

    // Guardamos en formato: iteraciones.saltBase64.hashBase64
    return $"100000.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
}

static bool VerifyPassword(string stored, string password)
{
    // Formato esperado: iterations.salt.hash
    var parts = stored.Split('.');
    if (parts.Length != 3) return false;
    if (!int.TryParse(parts[0], out int iterations)) return false;
    var salt = Convert.FromBase64String(parts[1]);
    var hash = Convert.FromBase64String(parts[2]);

    using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
    var computed = pbkdf2.GetBytes(hash.Length);
    return CryptographicOperations.FixedTimeEquals(computed, hash);
}
