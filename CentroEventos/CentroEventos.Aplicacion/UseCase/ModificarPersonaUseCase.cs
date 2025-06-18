namespace CentroEventos.Aplicacion;

public class ModificarPersonaUseCase(IRepositorioPersona repositorioPersona,
IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Persona persona, int idUsuario)
    {
        // 1. Autorización
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
            throw new FalloAutorizacionException("No tiene permiso para realizar esta acción.");

        // 2. Validar existencia de la persona
        var personaExistente = repositorioPersona.GetPersona(persona.Id);
        if (personaExistente == null)
            throw new EntidadNotFoundException("La persona no existe.");

        // 3. Modificar persona
        repositorioPersona.ModificarPersona(persona);
    }
}