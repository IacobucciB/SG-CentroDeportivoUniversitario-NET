namespace CentroEventos.Aplicacion;

public class Persona
{
    public int Id { get; set; }
    public string DNI { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;
    public List<Permiso> ListaPermisos { get; set; } = new List<Permiso>();
    public override string ToString()
    {
        var permisos = string.Join(", ", ListaPermisos.Select(p => p.ToString()));
        return $"Persona: {Id}, {DNI}, {Nombre}, {Apellido}, {Email}, {Telefono}, Permisos: [{permisos}]";
    }
}