using CentroEventos.UI.Components;
using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Casos de Uso
// Persona
builder.Services.AddTransient<AltaPersonaUseCase>();
builder.Services.AddTransient<BajaPersonaUseCase>();
builder.Services.AddTransient<ModificarPersonaUseCase>();
builder.Services.AddTransient<ListarPersonasUseCase>();
builder.Services.AddTransient<ObtenerPersonaPorIdUseCase>();

// Reserva
builder.Services.AddTransient<AltaReservaUseCase>();
builder.Services.AddTransient<BajaReservaUseCase>();
builder.Services.AddTransient<ModificarReservaUseCase>();
builder.Services.AddTransient<ListarReservasUseCase>();
builder.Services.AddTransient<ListarAsistenciaAEventoUseCase>();
builder.Services.AddTransient<ObtenerReservaPorIdUseCase>();

// Evento Deportivo
builder.Services.AddTransient<AltaEventoDeportivoUseCase>();
builder.Services.AddTransient<BajaEventoDeportivoUseCase>();
builder.Services.AddTransient<ModificarEventoDeportivoUseCase>();
builder.Services.AddTransient<ListarEventosDeportivosUseCase>();
builder.Services.AddTransient<ObtenerEventoDeportivoPorIdUseCase>();

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
builder.Services.AddScoped<ServicioSesion>();
builder.Services.AddTransient<IServicioHash, ServicioHash>();

builder.Services.AddTransient<ListarEventosConCupoDisponibleUseCase>();

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
    
    // var repoPersonaSQL = new RepositorioPersonaSQL();
    // var repoEventoSQL = new RepositorioEventoDeportivoSQL();
    // var repoReservaSQL = new RepositorioReservaSQL();

    // var listarPersonasSQL = new ListarPersonasUseCase(repoPersonaSQL);
    // var listarEventosSQL = new ListarEventosDeportivosUseCase(repoEventoSQL);
    // var listarReservasSQL = new ListarReservasUseCase(repoReservaSQL);

    // /*
    // // Limpiar datos previos
    // foreach (var r in listarReservasSQL.Ejecutar())
    // {
    //     repoReservaSQL.BajaReserva(r.Id);
    // }

    // foreach (var e in listarEventosSQL.Ejecutar())
    // {
    //     repoEventoSQL.BajaEventoDeportivo(e.Id);
    // }

    // foreach (var p in listarPersonasSQL.Ejecutar())
    // {
    //     repoPersonaSQL.EliminarPersona(p.Id);
    // }
    // */
    
    // var personaValidadorSQL = new PersonaValidador();
    // var servicioAutorizacionSQL = new ServicioAutorizacionProvisorio();
    // var servicioHashSQL = new ServicioHash();
    // var altaPersonaSQL = new AltaPersonaUseCase(repoPersonaSQL, personaValidadorSQL, servicioAutorizacionSQL);
    // if (listarPersonasSQL.Ejecutar().Count == 0)
    // {
    //     var personaSQL = new Persona
    //         {
    //         // Id = "1",
    //             DNI = "12345678",
    //             Nombre = "Juan SQL",
    //             Apellido = "Pérez SQL",
    //             Email = "test@gmail.com",
    //             Contrasena = servicioHashSQL.Hashear("aaa"),
    //             ListaPermisos = new List<Permiso> {
    //                 Permiso.EventoAlta, Permiso.EventoModificacion, Permiso.EventoBaja,
    //                 Permiso.ReservaAlta, Permiso.ReservaModificacion, Permiso.ReservaBaja,
    //                 Permiso.UsuarioAlta, Permiso.UsuarioModificacion, Permiso.UsuarioBaja
    //             }
    //         };
    //     altaPersonaSQL.Ejecutar(personaSQL, 1);
    //     Console.WriteLine("Persona SQL guardada correctamente.");
    // } 


    // // Listar personas con SQLite
    
    // Console.WriteLine("\nPersonas en SQLite:");
    // foreach (var p in listarPersonasSQL.Ejecutar())
    // {
    //     Console.WriteLine(p);
    // }

}