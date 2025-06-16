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
    var repoEventoSQL = new RepositorioEventoDeportivoSQL();
    var repoReservaSQL = new RepositorioReservaSQL();

    var listarPersonasSQL = new ListarPersonasUseCase(repoPersonaSQL);
    var listarEventosSQL = new ListarEventosDeportivosUseCase(repoEventoSQL);
    var listarReservasSQL = new ListarReservasUseCase(repoReservaSQL);

    // Limpiar datos previos
    foreach (var r in listarReservasSQL.Ejecutar())
    {
        repoReservaSQL.BajaReserva(r.Id);
    }

    foreach (var e in listarEventosSQL.Ejecutar())
    {
        repoEventoSQL.BajaEventoDeportivo(e.Id);
    }

    foreach (var p in listarPersonasSQL.Ejecutar())
    {
        repoPersonaSQL.EliminarPersona(p.Id);
    }

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

    var eventoDeportivoValidadorSQL = new EventoDeportivoValidador();
    var altaEventoSQL = new AltaEventoDeportivoUseCase(repoEventoSQL, repoPersonaSQL, servicioAutorizacionSQL, eventoDeportivoValidadorSQL);
    var eventoSQL = new EventoDeportivo
    {
        Nombre = "Fútbol SQL",
        Descripcion = "Partido de fútbol SQL",
        FechaHoraInicio = DateTime.Now.AddDays(5),
        DuracionHoras = 2,
        CupoMaximo = 8,
        ResponsableId = personaSQL.Id
    };
    Console.WriteLine("Evento SQL guardado correctamente.");

    var reservaValidadorSQL = new ReservaValidador();
    var altaReservaSQL = new AltaReservaUseCase(repoReservaSQL, repoEventoSQL, repoPersonaSQL, servicioAutorizacionSQL);
    var reservaSQL = new Reserva
    {
        PersonaId = personaSQL.Id,
        EventoDeportivoId = eventoSQL.Id,
        FechaAltaReserva = DateTime.Now,
        EstadoAsistencia = EstadoAsistencia.Pendiente
    };

    // Listar con SQLite
    Console.WriteLine("\nPersonas en SQLite:");
    foreach (var p in listarPersonasSQL.Ejecutar())
    {
        Console.WriteLine(p);
    }

    Console.WriteLine("\nEventos deportivos en SQLite:");
    foreach (var e in listarEventosSQL.Ejecutar())
    {
        Console.WriteLine(e);
    }

    Console.WriteLine("\nReservas en SQLite:");
    foreach (var r in listarReservasSQL.Ejecutar())
    {
        Console.WriteLine(r);
    }

    //Modificar
    var modificarPersona = new ModificarPersonasUseCase(repoPersonaSQL, servicioAutorizacionSQL);
    personaSQL = new Persona
    {
        Id = 1,
        DNI = "12345678",
        Nombre = "Juan SQL-modificado",
        Apellido = "Pérez SQL-modificado",
        Email = "test@gmail.com",
        Telefono = "111222"
    };
    modificarPersona.Ejecutar(personaSQL, 1);
    Console.WriteLine("Persona modificada correctamente.");

    Console.WriteLine("\nPersonas en SQLite mod:");
    foreach (var p in listarPersonasSQL.Ejecutar())
    {
        Console.WriteLine(p);
    }

}