namespace CentroEventos.Aplicacion;

public class BajaReservaUseCase(IRepositorioReserva repositorioReserva)
{
    public void Ejecutar(int id)
    {
        // 1. Validar existencia de la reserva
        var reserva = repositorioReserva.ObtenerReservaPorId(id);
        if (reserva == null)
            throw new EntidadNotFoundException("La reserva no existe.");

        // 2. Eliminar reserva
        repositorioReserva.BajaReserva(id);
    }
}