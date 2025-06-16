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
