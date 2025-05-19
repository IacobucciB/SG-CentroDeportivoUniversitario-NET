namespace CentroEventos.Aplicacion;

public class AltaPersonaUseCase(IRepositorioPersona repositorioPersona)
{ 
    public void Ejecutar(Persona persona)
    {
        repositorioPersona.AgregarPersona(persona);
    }
}