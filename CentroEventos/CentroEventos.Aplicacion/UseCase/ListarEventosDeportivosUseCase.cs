namespace CentroEventos.Aplicacion;

public class ListarEventosDeportivosUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo)
{ 
    public List<EventoDeportivo> Ejecutar()
    {
        return repositorioEventoDeportivo.ListarEventosDeportivos();
    }
}