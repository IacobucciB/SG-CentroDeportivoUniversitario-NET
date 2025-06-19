namespace CentroEventos.Aplicacion;

public class ObtenerEventoDeportivoPorIdUseCase(IRepositorioEventoDeportivo RepositorioEventoDeportivo)
{
    public EventoDeportivo Ejecutar(int idEventoDeportivo)
    {
        var eventoDeportivo = RepositorioEventoDeportivo.ObtenerEventoDeportivoPorId(idEventoDeportivo);

        if (eventoDeportivo == null)
            throw new EntidadNotFoundException("El evento deportivo no existe.");

        return eventoDeportivo;
    }
}