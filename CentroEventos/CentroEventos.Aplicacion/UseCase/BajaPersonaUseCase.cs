namespace CentroEventos.Aplicacion;

public class BajaPersonaUseCase(
    IRepositorioPersona repositorioPersona,
    IRepositorioEventoDeportivo repositorioEventoDeportivo,
    IRepositorioReserva repositorioReserva,
    IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int idPersona, int idUsuario)
    {
        // 1. Autorización
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja))
            throw new FalloAutorizacionException("No tiene permiso para realizar esta acción.");

        // 2. Validar existencia de la persona
        var persona = repositorioPersona.ObtenerPersonaPorId(idPersona);
        if (persona == null)
            throw new EntidadNotFoundException("La persona no existe.");
        
        // 3. Validar que la persona no esté asociada a eventos deportivos o reservas
        var eventosAsociados = repositorioEventoDeportivo.ListarEventosDeportivos();
        // Verificar si la persona tiene eventos deportivos asociados
        if (eventosAsociados.Any(evento => evento.ResponsableId == idPersona))
            throw new OperacionInvalidaException("La persona tiene eventos deportivos asociados.");
        var reservasAsociadas = repositorioReserva.ListarReservas();
        // Verificar si la persona tiene reservas asociadas
        if (reservasAsociadas.Any(reserva => reserva.PersonaId == idPersona))
            throw new OperacionInvalidaException("La persona tiene reservas asociadas.");
        // 4. Eliminar persona
        repositorioPersona.EliminarPersona(idPersona);
    }
}