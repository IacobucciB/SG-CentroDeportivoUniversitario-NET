using CentroEventos.UI.Components;

using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Casos de Uso
// Persona
builder.Services.AddTransient<AltaPersonaUseCase>();
builder.Services.AddTransient<BajaPersonaUseCase>();
builder.Services.AddTransient<ModificarPersonasUseCase>();
builder.Services.AddTransient<ListarPersonasUseCase>();
// Reserva
builder.Services.AddTransient<AltaReservaUseCase>();
builder.Services.AddTransient<BajaReservaUseCase>();
builder.Services.AddTransient<ModificarReservaUseCase>();
builder.Services.AddTransient<ListarReservasUseCase>();
// Evento Deportivo
builder.Services.AddTransient<AltaEventoDeportivoUseCase>();
builder.Services.AddTransient<BajaEventoDeportivoUseCase>();
builder.Services.AddTransient<ModificarEventoDeportivoUseCase>();
builder.Services.AddTransient<ListarEventosDeportivosUseCase>();
// Validadores
builder.Services.AddTransient<PersonaValidador>();
builder.Services.AddTransient<ReservaValidador>();
builder.Services.AddTransient<EventoDeportivoValidador>();

// Repositorios
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersonaSQL>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReservaSQL>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivoSQL>();

// Servicios
builder.Services.AddTransient<IServicioAutorizacion, ServicioAutorizacionProvisorio>();

// Inicializar DB SQLite
CentroEventosSqlite.Inicializar();

MockData();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


void MockData()
{
    var repoPersonaSQL = new RepositorioPersonaSQL();
    var personaValidadorSQL = new PersonaValidador();
    var servicioAutorizacionSQL = new ServicioAutorizacionProvisorio();
    var altaPersonaSQL = new AltaPersonaUseCase(repoPersonaSQL, personaValidadorSQL, servicioAutorizacionSQL);
    var personaSQL = new Persona
    {
        DNI = "12345678",
        Nombre = "Juan SQL",
        Apellido = "Pérez SQL",
        Email = "test@gmail.com"
    };
    altaPersonaSQL.Ejecutar(personaSQL, 1);
    Console.WriteLine("Persona SQL guardada correctamente.");

    // Listar personas con SQLite
    var listarPersonasSQL = new ListarPersonasUseCase(repoPersonaSQL);
    Console.WriteLine("\nPersonas en SQLite:");
    foreach (var p in listarPersonasSQL.Ejecutar())
    {
        Console.WriteLine(p);
    }

}