namespace CentroEventos.Aplicacion;

public class ModificarReservaUseCase(IRepositorioReserva repositorioReserva)
{
    public void Ejecutar(Reserva reserva)
    {
        // 1. Validar existencia de la reserva
        var reservaExistente = repositorioReserva.ObtenerReservaPorId(reserva.Id);
        if (reservaExistente == null)
            throw new EntidadNotFoundException("La reserva no existe.");

        // 2. Modificar reserva
        repositorioReserva.ModificarReserva(reserva);
    }
}