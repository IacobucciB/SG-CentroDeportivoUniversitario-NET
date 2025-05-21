namespace CentroEventos.Aplicacion;

public class BajaReservaUseCase(IRepositorioReserva repositorioReserva,
IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int id, int idUsuario)
    {
        // 1. Autorización
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
            throw new FalloAutorizacionException("No tiene permiso para realizar esta acción.");
        // 2. Validar existencia de la reserva
        var reserva = repositorioReserva.ObtenerReservaPorId(id);
        if (reserva == null)
            throw new EntidadNotFoundException("La reserva no existe.");

        // 3. Eliminar reserva
        repositorioReserva.BajaReserva(id);
    }
}