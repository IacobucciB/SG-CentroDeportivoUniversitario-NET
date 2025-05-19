namespace CentroEventos.Aplicacion;

public class ListarPersonasUseCase(IRepositorioPersona repositorioPersona)
{
    public List<Persona> Ejecutar()
    {
        return repositorioPersona.ListarPersonas();
    }
}