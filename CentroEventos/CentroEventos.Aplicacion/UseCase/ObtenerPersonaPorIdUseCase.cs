namespace CentroEventos.Aplicacion;

public class ObtenerPersonaPorIdUseCase(IRepositorioPersona RepositorioPersona)
{
    public Persona Ejecutar(int idPersona)
    {
        var persona = RepositorioPersona.ObtenerPersonaPorId(idPersona);

        if (persona == null)
            throw new EntidadNotFoundException("La persona no existe.");

        return persona;
    }
}