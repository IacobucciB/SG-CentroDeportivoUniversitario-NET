namespace CentroEventos.Aplicacion;

public class ModificarPersonasUseCase(IRepositorioPersona repositorioPersona)
{
    public void Ejecutar(Persona persona)
    {
        repositorioPersona.ModificarPersona(persona);
    }
}