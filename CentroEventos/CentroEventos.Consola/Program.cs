using System.Diagnostics.CodeAnalysis;
using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;

void EjemploValido()
{
    // Configuro las dependencias
    IRepositorioEventoDeportivo repo = new RepositorioEventoDeportivoTXT();
    // Creo los casos de uso
    var altaEvento = new AltaEventoDeportivoUseCase(repo);
    var listarEventos = new ListarEventosDeportivosUseCase(repo);
    // Ejecuto los casos de uso
    altaEvento.Ejecutar(new EventoDeportivo()
    {
        Id = 1,
        Nombre = "Fútbol 5",
        Descripcion = "Torneo de fútbol 5 universitario",
        FechaHoraInicio = DateTime.Now.AddDays(1),
        DuracionHoras = 2,
        CupoMaximo = 10,
        ResponsableId = 1
    });
    altaEvento.Ejecutar(new EventoDeportivo()
    {
        Id = 2,
        Nombre = "Básquet",
        Descripcion = "Encuentro amistoso de básquet",
        FechaHoraInicio = DateTime.Now.AddDays(2),
        DuracionHoras = 1.5,
        CupoMaximo = 12,
        ResponsableId = 2
    });
    altaEvento.Ejecutar(new EventoDeportivo()
    {
        Id = 3,
        Nombre = "Vóley",
        Descripcion = "Torneo relámpago de vóley mixto",
        FechaHoraInicio = DateTime.Now.AddDays(3),
        DuracionHoras = 2,
        CupoMaximo = 8,
        ResponsableId = 1
    });
    var lista = listarEventos.Ejecutar();
    foreach (EventoDeportivo e in lista)
    {
        Console.WriteLine(e);
    }
    // Ejemplo similar para Persona
    IRepositorioPersona repoPersona = new RepositorioPersonaTXT();
    var altaPersona = new AltaPersonaUseCase(repoPersona);
    var listarPersonas = new ListarPersonasUseCase(repoPersona);

    altaPersona.Ejecutar(new Persona()
    {
        Id = 1,
        Nombre = "Juan Pérez",
        Email = "juan.perez@email.com"
    });
    altaPersona.Ejecutar(new Persona()
    {
        Id = 2,
        Nombre = "María Gómez",
        Email = "maria.gomez@email.com"
    });
    altaPersona.Ejecutar(new Persona()
    {
        Id = 3,
        Nombre = "Carlos Ruiz",
        Email = "carlos.ruiz@email.com"
    });

    var personas = listarPersonas.Ejecutar();
    foreach (Persona p in personas)
    {
        Console.WriteLine(p);
    }

    // Baja de un evento
    var bajaEvento = new BajaEventoDeportivoUseCase(repo);
    bajaEvento.Ejecutar(2); // Elimina el evento con Id = 2

    // Modificación de un evento
    var modificarEvento = new ModificarEventoDeportivoUseCase(repo);
    modificarEvento.Ejecutar(new EventoDeportivo()
    {
        Id = 1,
        Nombre = "Fútbol 5 cambiado",
        Descripcion = "Torneo de fútbol 5 universitario re loco",
        FechaHoraInicio = DateTime.Now.AddDays(1),
        DuracionHoras = 2.5,
        CupoMaximo = 12,
        ResponsableId = 1
    });

    // Baja de una persona
    var bajaPersona = new BajaPersonaUseCase(repoPersona);
    bajaPersona.Ejecutar(3); // Elimina la persona con Id = 3

    // Modificación de una persona
    var modificarPersona = new ModificarPersonasUseCase(repoPersona);
    modificarPersona.Ejecutar(new Persona()
    {
        Id = 2,
        Nombre = "María Gómez De la Torre",
        Email = "maria.gomez.delatorre@email.com"
    });

    // Mostrar resultados después de las operaciones
    Console.WriteLine("Eventos después de baja y modificación:");
    foreach (EventoDeportivo e in listarEventos.Ejecutar())
    {
        Console.WriteLine(e);
    }

    Console.WriteLine("Personas después de baja y modificación:");
    foreach (Persona p in listarPersonas.Ejecutar())
    {
        Console.WriteLine(p);
    }
    
    IRepositorioReserva repoReserva = new RepositorioReservaTXT();
    IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();
    var altaReserva = new AltaReservaUseCase(repoReserva, repo, repoPersona, servicioAutorizacion);
    var listarReservas = new ListarReservasUseCase(repoReserva);

    altaReserva.Ejecutar(new Reserva()
    {
        Id = 1,
        EventoDeportivoId = 1,
        PersonaId = 1,
        FechaAltaReserva = DateTime.Now,
        EstadoAsistencia = EstadoAsistencia.Presente
    }, 1);
    altaReserva.Ejecutar(new Reserva()
    {
        Id = 2,
        EventoDeportivoId = 3,
        FechaAltaReserva = DateTime.Now.AddHours(1),
        EstadoAsistencia = EstadoAsistencia.Pendiente
    }, 2);
    altaReserva.Ejecutar(new Reserva()
    {
        Id = 3,
        EventoDeportivoId = 1,
        FechaAltaReserva = DateTime.Now.AddHours(2),
        EstadoAsistencia = EstadoAsistencia.Ausente
    }, 3);

    var reservas = listarReservas.Ejecutar();
    foreach (Reserva r in reservas)
    {
        Console.WriteLine(r);
    }

    // Baja de una reserva
    var bajaReserva = new BajaReservaUseCase(repoReserva);
    bajaReserva.Ejecutar(2); // Elimina la reserva con Id = 2

    // Modificación de una reserva
    var modificarReserva = new ModificarReservaUseCase(repoReserva);
    modificarReserva.Ejecutar(new Reserva()
    {
        Id = 1,
        EventoDeportivoId = 1,
        PersonaId = 1,
        FechaAltaReserva = DateTime.Now,
        EstadoAsistencia = EstadoAsistencia.Pendiente
    });

    // Mostrar resultados después de las operaciones
    Console.WriteLine("Reservas después de baja y modificación:");
    foreach (Reserva r in listarReservas.Ejecutar())
    {
        Console.WriteLine(r);
    }
}

EjemploValido();


