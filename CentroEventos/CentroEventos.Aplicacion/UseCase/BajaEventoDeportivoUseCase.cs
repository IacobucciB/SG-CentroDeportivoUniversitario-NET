namespace CentroEventos.Aplicacion;

public class BajaEventoDeportivoUseCase(
    IRepositorioEventoDeportivo repositorioEventoDeportivo,
    IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int idEvento, int idUsuario)
    {
        // 1. Autorización
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
            throw new FalloAutorizacionException("No tiene permiso para realizar esta acción.");

        // 2. Validar existencia del evento
        var evento = repositorioEventoDeportivo.ObtenerEventoDeportivoPorId(idEvento);
        if (evento == null)
            throw new EntidadNotFoundException("El evento deportivo no existe.");

        // 3. Eliminar evento
        repositorioEventoDeportivo.BajaEventoDeportivo(idEvento);
    }
}