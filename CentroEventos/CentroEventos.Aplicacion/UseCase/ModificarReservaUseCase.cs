namespace CentroEventos.Aplicacion;

public class ModificarReservaUseCase(IRepositorioReserva repositorioReserva,
IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Reserva reserva, int idUsuario)
    {
        // 1. Autorización
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion))
            throw new FalloAutorizacionException("No tiene permiso para realizar esta acción.");
        // 2. Validar existencia de la reserva
        var reservaExistente = repositorioReserva.ObtenerReservaPorId(reserva.Id);
        if (reservaExistente == null)
            throw new EntidadNotFoundException("La reserva no existe.");

        // 3. Modificar reserva
        repositorioReserva.ModificarReserva(reserva);
    }
}