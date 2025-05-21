using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;

void MainMenu()
{
    // Repositorios
    var repoPersona = new RepositorioPersonaTXT();
    var repoEvento = new RepositorioEventoDeportivoTXT();
    var repoReserva = new RepositorioReservaTXT();

    // Validadores
    var personaValidador = new PersonaValidador();
    var eventoValidador = new EventoDeportivoValidador();
    var reservaValidador = new ReservaValidador();

    // Servicio de autorización provisorio (mock)
    IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();

    // Casos de uso
    var altaPersona = new AltaPersonaUseCase(repoPersona, personaValidador, servicioAutorizacion);
    var altaEvento = new AltaEventoDeportivoUseCase(repoEvento, repoPersona, servicioAutorizacion, eventoValidador);
    var altaReserva = new AltaReservaUseCase(repoReserva, repoEvento, repoPersona, servicioAutorizacion);

    var listarPersonas = new ListarPersonasUseCase(repoPersona);
    var listarEventos = new ListarEventosDeportivosUseCase(repoEvento);
    var listarReservas = new ListarReservasUseCase(repoReserva);

    while (true)
    {
        Console.WriteLine("\n--- MENÚ ---");
        Console.WriteLine("1. Crear y guardar ejemplos válidos");
        Console.WriteLine("2. Probar excepciones de validación");
        Console.WriteLine("3. Listar entidades");
        Console.WriteLine("0. Salir");
        Console.Write("Seleccione una opción: ");
        var opcion = Console.ReadLine();

        try
        {
            switch (opcion)
            {
                case "1":
                    // Persona válida
                    var persona = new Persona { DNI = "12345678", Nombre = "Juan", Apellido = "Pérez", Email = "juan@mail.com", Telefono = "123456" };
                    altaPersona.Ejecutar(persona, 1);
                    Console.WriteLine("Persona guardada correctamente.");
                    // Otra persona válida reutilizando la variable persona
                    var persona2 = new Persona { DNI = "23456789", Nombre = "Ana", Apellido = "García", Email = "ana@mail.com", Telefono = "987654" };
                    altaPersona.Ejecutar(persona2, 1);
                    Console.WriteLine("Segunda persona guardada correctamente.");
                    // Evento válido (el responsable existe)
                    var evento = new EventoDeportivo
                    {
                        Nombre = "Voley",
                        Descripcion = "Torneo de voley universitario",
                        FechaHoraInicio = DateTime.Now.AddDays(3),
                        DuracionHoras = 2,
                        CupoMaximo = 8,
                        ResponsableId = persona.Id
                    };
                    altaEvento.Ejecutar(evento, 1);
                    Console.WriteLine("Evento guardado correctamente.");
                    // Otro evento válido (el responsable es persona2)
                    var evento2 = new EventoDeportivo
                    {
                        Nombre = "Fútbol",
                        Descripcion = "Partido amistoso de fútbol",
                        FechaHoraInicio = DateTime.Now.AddDays(5),
                        DuracionHoras = 1,
                        CupoMaximo = 10,
                        ResponsableId = persona2.Id
                    };
                    altaEvento.Ejecutar(evento2, 1);
                    Console.WriteLine("Segundo evento guardado correctamente.");
                    // Reserva válida
                    var reserva = new Reserva
                    {
                        PersonaId = persona.Id,
                        EventoDeportivoId = evento.Id
                    };
                    altaReserva.Ejecutar(reserva, 1);
                    Console.WriteLine("Reserva guardada correctamente.");
                    reserva = new Reserva
                    {
                        PersonaId = persona2.Id,
                        EventoDeportivoId = evento2.Id
                    };
                    altaReserva.Ejecutar(reserva, 1);
                    Console.WriteLine("Segunda reserva guardada correctamente.");
                    break;

                case "2":
                    // Persona inválida (nombre vacío)
                    try
                    {
                        var personaInvalida = new Persona { DNI = "87654321", Nombre = "", Apellido = "SinNombre", Email = "sin@mail.com", Telefono = "654321" };
                        altaPersona.Ejecutar(personaInvalida, 1);
                    }
                    catch (ValidacionException ex)
                    {
                        Console.WriteLine($"Excepción de validación Persona: {ex.Message}");
                    }

                    // Evento inválido (fecha pasada)
                    try
                    {
                        var eventoInvalido = new EventoDeportivo
                        {
                            Nombre = "Evento pasado",
                            Descripcion = "No debería guardarse",
                            FechaHoraInicio = DateTime.Now.AddDays(-1),
                            DuracionHoras = 1,
                            CupoMaximo = 5,
                            ResponsableId = 999 // No existe
                        };
                        altaEvento.Ejecutar(eventoInvalido, 1);
                    }
                    catch (ValidacionException ex)
                    {
                        Console.WriteLine($"Excepción de validación Evento: {ex.Message}");
                    }
                    catch (EntidadNotFoundException ex)
                    {
                        Console.WriteLine($"Excepción de entidad Evento: {ex.Message}");
                    }

                    // Reserva inválida (duplicada)
                    try
                    {
                        var personas = listarPersonas.Ejecutar();
                        var eventos = listarEventos.Ejecutar();
                        if (personas.Count > 0 && eventos.Count > 0)
                        {
                            var reservaDuplicada = new Reserva
                            {
                                PersonaId = personas[0].Id,
                                EventoDeportivoId = eventos[0].Id
                            };
                            // Primera vez OK
                            altaReserva.Ejecutar(reservaDuplicada, 1);
                            // Segunda vez lanza excepción
                            altaReserva.Ejecutar(reservaDuplicada, 1);
                        }
                    }
                    catch (DuplicadoException ex)
                    {
                        Console.WriteLine($"Excepción de duplicado Reserva: {ex.Message}");
                    }
                    break;

                case "3":
                    Console.WriteLine("\nPersonas:");
                    foreach (var p in listarPersonas.Ejecutar())
                        Console.WriteLine(p);

                    Console.WriteLine("\nEventos:");
                    foreach (var e in listarEventos.Ejecutar())
                        Console.WriteLine(e);

                    Console.WriteLine("\nReservas:");
                    foreach (var r in listarReservas.Ejecutar())
                        Console.WriteLine(r);
                    break;
                case "4":
                    // Baja de de reserva Valida
                    // Se asume que existe y que el usuario tiene permiso
                    // La baja de las demás entidades se hace de forma similar
                    var bajaReserva = new BajaReservaUseCase(repoReserva, servicioAutorizacion);
                    bajaReserva.Ejecutar(2, 1);
                    Console.WriteLine("Reserva eliminada correctamente.");
                    break;
                case "5":
                    // Modificacion de persona valida
                    // Se asume que existe
                    // La modificación de las demás entidades se hace de forma similar
                    var modificarPersona = new ModificarPersonasUseCase(repoPersona, servicioAutorizacion);
                    var personaModificada = new Persona
                    {
                        Id = 2,
                        DNI = "23456789",
                        Nombre = "Ana Modificada",
                        Apellido = "García Modificada",
                        Email = "ana_modificada@mail.com",
                        Telefono = "111222"
                    };
                    modificarPersona.Ejecutar(personaModificada, 1);
                    Console.WriteLine("Persona modificada correctamente.");
                    break;
                case "6":

                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
        catch (FalloAutorizacionException ex)
        {
            Console.WriteLine($"Excepción de autorización: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción inesperada: {ex.Message}");
        }
    }
}

MainMenu();


