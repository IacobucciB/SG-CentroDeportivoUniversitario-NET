namespace CentroEventos.Aplicacion;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo)
{ 
    public void Ejecutar(EventoDeportivo eventoDeportivo)
    {
        repositorioEventoDeportivo.ModificarEventoDeportivo(eventoDeportivo);
    }
}