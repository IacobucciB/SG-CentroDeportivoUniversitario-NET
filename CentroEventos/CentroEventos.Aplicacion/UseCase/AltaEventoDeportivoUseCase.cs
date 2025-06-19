namespace CentroEventos.Aplicacion;

public class AltaEventoDeportivoUseCase(
    IRepositorioEventoDeportivo repositorioEventoDeportivo,
    IRepositorioPersona repositorioPersona,
    IServicioAutorizacion servicioAutorizacion,
    EventoDeportivoValidador validador)
{
    public void Ejecutar(EventoDeportivo eventoDeportivo, int idUsuario)
    {
        // 1. Autorización
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoAlta))
            throw new FalloAutorizacionException("No tiene permiso para realizar esta acción.");

        // 2. Validar datos del evento
        if (!validador.Validar(eventoDeportivo, out string mensajeError))
            throw new ValidacionException(mensajeError);
        

        // 3. Validar existencia del responsable
        var responsable = repositorioPersona.ObtenerPersonaPorId(eventoDeportivo.ResponsableId);
        if (responsable == null)
            throw new EntidadNotFoundException("El responsable no existe.");

        // 4. Guardar evento
        repositorioEventoDeportivo.AltaEventoDeportivo(eventoDeportivo);
    }
}
