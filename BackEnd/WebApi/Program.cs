using CapaDatos;
using CapaDomain;

var builder = WebApplication.CreateBuilder(args);

// Cargar la configuración desde appsettings.json
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Registrar el patrón Singleton para la conexión a la base de datos
builder.Services.AddSingleton(provider =>
    ConexionSingleton.GetInstance(provider.GetRequiredService<IConfiguration>()));

// Registrar el repositorio y la capa de dominio
builder.Services.AddScoped<AlumnoRepository>();
builder.Services.AddScoped<AlumnoDomain>();

<<<<<<< HEAD
<<<<<<< HEAD
builder.Services.AddScoped<ArtistaRepository>();
builder.Services.AddScoped<ArtistaDomain>();
=======
=======

builder.Services.AddScoped<RolRepository>();
builder.Services.AddScoped<RolDomain>();

builder.Services.AddScoped<CancionRepository>();
builder.Services.AddScoped<CancionDomain>();

builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<UsuarioDomain>();


>>>>>>> 60583a20000bd6f6025baa2f75f206de34c367dc
builder.Services.AddScoped<PlaRepository>();
builder.Services.AddScoped<PlaDomain>();
>>>>>>> 466e05afc66a47e4502deffb9e1d823468b17e92


// Registrar los controladores
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();