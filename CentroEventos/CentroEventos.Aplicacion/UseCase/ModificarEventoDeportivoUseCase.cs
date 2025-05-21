namespace CentroEventos.Aplicacion;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo,
IServicioAutorizacion servicioAutorizacion)
{ 
    public void Ejecutar(EventoDeportivo eventoDeportivo, int idUsuario)
    {
        // 1. Autorización
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
            throw new FalloAutorizacionException("No tiene permiso para realizar esta acción.");
        // 2. Validar existencia del evento
        var eventoExistente = repositorioEventoDeportivo.GetEventoDeportivo(eventoDeportivo.Id);
        if (eventoExistente == null)
            throw new EntidadNotFoundException("El evento deportivo no existe.");

        // 3. Modificar evento
        repositorioEventoDeportivo.ModificarEventoDeportivo(eventoDeportivo);
    }
}