namespace CentroEventos.Aplicacion;

public class RegistrarPersonaUseCase(
    IRepositorioPersona repositorioPersona,
    PersonaValidador validador)
{
    public void Ejecutar(Persona persona)
    {
        
        // 1. Validar datos de la persona
        if (!validador.Validar(persona, out string mensajeError))
            throw new ValidacionException(mensajeError);
        
        // 2. Verificar si sos la primera persona registrada, y si fuera el caso, asignarle todos los permisos  (admin)
        if (repositorioPersona.ListarPersonas().Count == 0)
        {
            persona.ListaPermisos = Enum.GetValues(typeof(Permiso)).Cast<Permiso>().ToList();
        }
            
        // 3. Guardar persona
        repositorioPersona.AgregarPersona(persona);
    }
}