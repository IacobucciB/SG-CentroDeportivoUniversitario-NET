namespace CentroEventos.Aplicacion;

public class ListarReservasUseCase(IRepositorioReserva repositorioReserva)
{
    public List<Reserva> Ejecutar()
    {
        return repositorioReserva.ListarReservas();
    }
}