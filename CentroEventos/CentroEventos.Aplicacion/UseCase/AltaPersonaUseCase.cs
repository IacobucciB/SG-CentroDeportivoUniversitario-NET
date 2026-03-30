namespace CentroEventos.Aplicacion;

public class AltaPersonaUseCase(
    IRepositorioPersona repositorioPersona,
    PersonaValidador validador,
    IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Persona persona, int idUsuario)
    {
        // 1. Autorización
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioAlta))
            throw new FalloAutorizacionException("No tiene permiso para realizar esta acción.");

        // 2. Validar datos de la persona
        if (!validador.Validar(persona, out string mensajeError))
            throw new ValidacionException(mensajeError);

        // 3. Guardar persona
        repositorioPersona.AgregarPersona(persona);
    }
}