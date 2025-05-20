namespace CentroEventos.Aplicacion;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo)
{ 
    public void Ejecutar(EventoDeportivo eventoDeportivo)
    {
        // 1. Validar existencia del evento
        var eventoExistente = repositorioEventoDeportivo.GetEventoDeportivo(eventoDeportivo.Id);
        if (eventoExistente == null)
            throw new EntidadNotFoundException("El evento deportivo no existe.");

        // 2. Modificar evento
        repositorioEventoDeportivo.ModificarEventoDeportivo(eventoDeportivo);
    }
}