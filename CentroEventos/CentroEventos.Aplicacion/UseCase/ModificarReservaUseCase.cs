namespace CentroEventos.Aplicacion;

public class ModificarReservaUseCase(IRepositorioReserva repositorioReserva)
{
    public void Ejecutar(Reserva reserva)
    {
        repositorioReserva.ModificarReserva(reserva);
    }
}