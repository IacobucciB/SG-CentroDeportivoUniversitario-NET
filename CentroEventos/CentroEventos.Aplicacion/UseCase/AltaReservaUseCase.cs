namespace CentroEventos.Aplicacion;

public class AltaReservaUseCase(
    IRepositorioReserva repositorioReserva,
    IRepositorioEventoDeportivo repositorioEventoDeportivo,
    IRepositorioPersona repositorioPersona,
    IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Reserva datosReserva, int idUsuario)
    {
        // 1. Autorización
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
            throw new FalloAutorizacionException("No tiene permiso para realizar esta acción.");

        // 2. Validar existencia de Persona y Evento
        var persona = repositorioPersona.GetPersona(datosReserva.PersonaId);
        if (persona == null)
            throw new EntidadNotFoundException("La persona no existe.");

        var evento = repositorioEventoDeportivo.GetEventoDeportivo(datosReserva.EventoDeportivoId);
        if (evento == null)
            throw new EntidadNotFoundException("El evento deportivo no existe.");

        // 3. Validar cupo disponible
        var reservasEvento = repositorioReserva.ListarReservasPorEvento(datosReserva.EventoDeportivoId);
        if (reservasEvento.Count >= evento.CupoMaximo)
            throw new CupoExcedidoException("No hay cupo disponible para este evento.");

        // 4. Validar duplicado
        if (repositorioReserva.ExisteReserva(datosReserva.PersonaId, datosReserva.EventoDeportivoId))
            throw new DuplicadoException("La persona ya tiene una reserva para este evento.");

        // 5. Completar y guardar reserva
        datosReserva.FechaAltaReserva = DateTime.Now;
        datosReserva.EstadoAsistencia = EstadoAsistencia.Pendiente;
        repositorioReserva.AltaReserva(datosReserva);
    }
}