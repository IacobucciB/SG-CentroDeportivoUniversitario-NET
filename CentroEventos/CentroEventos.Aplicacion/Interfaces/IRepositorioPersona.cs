namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    void AgregarPersona(Persona persona);
    void ModificarPersona(Persona persona);
    void EliminarPersona(int id);

    List<Persona> ListarPersonas();

    Persona? GetPersona(int id);
}