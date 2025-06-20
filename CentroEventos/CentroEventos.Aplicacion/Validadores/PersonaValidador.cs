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
        if (string.IsNullOrWhiteSpace(persona.Contrasena))
        {
            mensajeError = "La contrasena no puede estar vacia.";
        }
        if (!string.IsNullOrWhiteSpace(persona.DNI) && !persona.DNI.All(char.IsDigit))
        {
            mensajeError = "El DNI debe estar compuesto solo por numeros.";
        }


        return (mensajeError == "");
    }
}
