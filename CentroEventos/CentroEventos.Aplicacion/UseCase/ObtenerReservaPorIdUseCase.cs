namespace CentroEventos.Aplicacion;

public class ObtenerReservaPorIdUseCase (IRepositorioReserva RepositorioReserva)
{
    public Reserva Ejecutar(int idReserva)
    {
        var reserva = RepositorioReserva.ObtenerReservaPorId(idReserva);

        if (reserva == null)
            throw new EntidadNotFoundException("La reserva no existe.");

        return reserva;
    }
}