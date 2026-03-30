namespace CentroEventos.Aplicacion;

public interface IRepositorioEventoDeportivo
{
    void AltaEventoDeportivo(EventoDeportivo eventoDeportivo);
    void BajaEventoDeportivo(int id);
    void ModificarEventoDeportivo(EventoDeportivo eventoDeportivo);
    List<EventoDeportivo> ListarEventosDeportivos();

    EventoDeportivo? ObtenerEventoDeportivoPorId(int id);

}