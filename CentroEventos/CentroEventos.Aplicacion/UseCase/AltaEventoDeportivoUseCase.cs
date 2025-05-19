namespace CentroEventos.Aplicacion;
public class AltaEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo)
{
    public void Ejecutar(EventoDeportivo eventoDeportivo)
    {
        repositorioEventoDeportivo.AltaEventoDeportivo(eventoDeportivo);
    }
}
