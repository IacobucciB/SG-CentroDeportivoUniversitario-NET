namespace CentroEventos.Aplicacion;

public class AltaReservaUseCase(IRepositorioReserva repositorioReserva)
{
    public void Ejecutar(Reserva reserva)
    {
        repositorioReserva.AltaReserva(reserva);
    }
}