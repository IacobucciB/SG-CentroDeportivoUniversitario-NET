namespace CentroEventos.Aplicacion;

public class PersonaValidador
{
    public bool Validar(Persona persona, out string mensajeError)
    {
        mensajeError = "";

        if (string.IsNullOrWhiteSpace(persona.Nombre))
        {
            mensajeError = "El nombre no puede estar vacío.";
        }
        if (string.IsNullOrWhiteSpace(persona.Apellido))
        {
            mensajeError = "El apellido no puede estar vacío.";
        }
        if (string.IsNullOrWhiteSpace(persona.Email))
        {
            mensajeError = "El email no puede estar vacío.";
        }
        return (mensajeError == "");
    }
}