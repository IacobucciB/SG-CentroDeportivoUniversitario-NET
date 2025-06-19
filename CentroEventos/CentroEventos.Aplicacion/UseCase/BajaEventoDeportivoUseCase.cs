namespace CentroEventos.Aplicacion;

public class BajaEventoDeportivoUseCase(
    IRepositorioEventoDeportivo repositorioEventoDeportivo,
    IRepositorioReserva repositorioReserva,
    IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int idEvento, int idUsuario)
    {
        // 1. Autorización
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
            throw new FalloAutorizacionException("No tiene permiso para realizar esta acción.");

        // 2. Validar existencia del evento
        var evento = repositorioEventoDeportivo.GetEventoDeportivo(idEvento);
        if (evento == null)
            throw new EntidadNotFoundException("El evento deportivo no existe.");

        //3. Validar que no existan reservas asociadas
        var reservasEvento = repositorioReserva.ListarReservasPorEvento(idEvento);
        if (reservasEvento.Count > 0)
            throw new OperacionInvalidaException("El evento deportivo tiene reservas asociadas.");

        // 4. Eliminar evento
        repositorioEventoDeportivo.BajaEventoDeportivo(idEvento);
    }
}