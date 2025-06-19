namespace CentroEventos.Aplicacion;

public class BajaPersonaUseCase(
    IRepositorioPersona repositorioPersona,
    IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int idPersona, int idUsuario)
    {
        // 1. Autorización
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja))
            throw new FalloAutorizacionException("No tiene permiso para realizar esta acción.");

        // 2. Validar existencia de la persona
        var persona = repositorioPersona.ObtenerPersonaPorId(idPersona);
        if (persona == null)
            throw new EntidadNotFoundException("La persona no existe.");

        // 3. Eliminar persona
        repositorioPersona.EliminarPersona(idPersona);
    }
}