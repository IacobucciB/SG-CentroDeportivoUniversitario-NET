namespace CentroEventos.Aplicacion;

public class ModificarPersonasUseCase(IRepositorioPersona repositorioPersona)
{
    public void Ejecutar(Persona persona)
    {
        // 1. Validar existencia de la persona
        var personaExistente = repositorioPersona.GetPersona(persona.Id);
        if (personaExistente == null)
            throw new EntidadNotFoundException("La persona no existe.");

        // 2. Modificar persona
        repositorioPersona.ModificarPersona(persona);
    }
}