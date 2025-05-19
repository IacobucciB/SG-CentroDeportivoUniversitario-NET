namespace CentroEventos.Aplicacion;

public class Persona
{
    public int Id { get; set; }
    public string DNI { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string Email { get; set; } = "";
    public string Telefono { get; set; } = "";

    public override string ToString()
    {
        return $"Persona: {Id}, {DNI}, {Nombre}, {Apellido}, {Email}, {Telefono}";
    }
}

public class PersonaValidador
{
    public bool Validar(Persona persona)
    {
        mensajeError = "";
        if (persona == null)
        {
            mensajeError = "La persona no puede ser nula.";
        }
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