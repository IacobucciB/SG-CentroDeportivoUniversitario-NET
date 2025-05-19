namespace CentroEventos.Aplicacion;

public class BajaPersonaUseCase(IRepositorioPersona repositorioPersona)
{
    public void Ejecutar(int id)
    {
        repositorioPersona.EliminarPersona(id);
    }
}