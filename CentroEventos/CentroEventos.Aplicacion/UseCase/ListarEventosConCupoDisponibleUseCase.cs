namespace CentroEventos.Aplicacion;

public class ListarEventosConCupoDisponibleUseCase(
    IRepositorioEventoDeportivo repositorioEventoDeportivo,
    IRepositorioReserva repositorioReserva)
{
    public List<EventoDeportivo> Ejecutar(int idUsuario)
    {
        // Obtener eventos deportivos cuya FechaHoraInicio sea futura
        var eventos = repositorioEventoDeportivo.ListarEventosDeportivos()
            .Where(evento => evento.FechaHoraInicio > DateTime.Now);

        // Filtrar eventos con cupo disponible
        var eventosConCupo = eventos.Where(evento =>
        {
            var reservasEvento = repositorioReserva.ListarReservasPorEvento(evento.Id);
            return reservasEvento.Count < evento.CupoMaximo;
        }).ToList();

        return eventosConCupo;
    }
}