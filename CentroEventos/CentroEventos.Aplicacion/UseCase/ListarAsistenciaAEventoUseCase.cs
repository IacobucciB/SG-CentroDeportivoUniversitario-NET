namespace CentroEventos.Aplicacion;


public class ListarAsistenciaAEventoUseCase(IRepositorioReserva repositorioReserva)
{
    public List<Reserva> Ejecutar()
    {
        // Obtener reservas cuya asistencia fue "Presente"
        var reserva = repositorioReserva.ListarReservas()
            .Where(reserva => reserva.EstadoAsistencia == EstadoAsistencia.Presente).ToList();
        if (reserva == null || reserva.Count == 0)
        {
            throw new Exception("No hay reservas con asistencia registrada.");
        }
        

        return reserva;
    }
}