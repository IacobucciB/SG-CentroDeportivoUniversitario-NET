namespace CentroEventos.Aplicacion;

public class ListarAsistenciaAEventoUseCase(IRepositorioReserva repositorioReserva)
{
    public List<Reserva> Ejecutar(int idEvento)
    {
        // Devuelve todas las reservas (asistencias) para el evento deportivo indicado
        return repositorioReserva.ListarReservasPorEvento(idEvento);
    }
}