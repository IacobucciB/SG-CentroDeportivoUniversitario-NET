namespace CentroEventos.Repositorios;

using System.Security.Cryptography.X509Certificates;
using CentroEventos.Aplicacion;

public class RepositorioPersonaTXT : IRepositorioPersona
{
    readonly string _nombreArch = "personas.txt";
    public void AgregarPersona(Persona persona)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(persona.Id);
        sw.WriteLine(persona.DNI);
        sw.WriteLine(persona.Nombre);
        sw.WriteLine(persona.Apellido);
        sw.WriteLine(persona.Email);
        sw.WriteLine(persona.Telefono);
    }
    public List<Persona> ListarPersonas()
    {
        var resultado = new List<Persona>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var persona = new Persona();
            persona.Id = int.Parse(sr.ReadLine() ?? "");
            persona.DNI = sr.ReadLine() ?? "";
            persona.Nombre = sr.ReadLine() ?? "";
            persona.Apellido = sr.ReadLine() ?? "";
            persona.Email = sr.ReadLine() ?? "";
            persona.Telefono = sr.ReadLine() ?? "";
            resultado.Add(persona);
        }
        return resultado;
    }
    public void ModificarPersona(Persona persona)
    {
        var personas = ListarPersonas();
        var personaModificar = personas.FirstOrDefault(p => p.Id == persona.Id);
        if (personaModificar != null)
        {
            personaModificar.DNI = persona.DNI;
            personaModificar.Nombre = persona.Nombre;
            personaModificar.Apellido = persona.Apellido;
            personaModificar.Email = persona.Email;
            personaModificar.Telefono = persona.Telefono;
        }
        //GuardarCambios(personas);
    }
}