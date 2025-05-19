namespace CentroEventos.Repositorios;

<<<<<<< HEAD
=======
using System.Security.Cryptography.X509Certificates;
>>>>>>> origin/personaNeme
using CentroEventos.Aplicacion;

public class RepositorioPersonaTXT : IRepositorioPersona
{
<<<<<<< HEAD
    readonly string _nombreArch = "persona.txt";
    readonly string _ultimoIdArch = "ultimoIdPersona.txt";

    public int ObtenerNuevoId()
    {
        int ultimoId = 0;
        if (File.Exists(_ultimoIdArch))
        {
            ultimoId = int.Parse(File.ReadAllText(_ultimoIdArch));
        }
        ultimoId++;
        File.WriteAllText(_ultimoIdArch, ultimoId.ToString());
        return ultimoId;
    }

    public void AltaPersona(Persona persona)
    {
        persona.Id = ObtenerNuevoId();
=======
    readonly string _nombreArch = "personas.txt";
    public void AgregarPersona(Persona persona)
    {
>>>>>>> origin/personaNeme
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(persona.Id);
        sw.WriteLine(persona.DNI);
        sw.WriteLine(persona.Nombre);
        sw.WriteLine(persona.Apellido);
        sw.WriteLine(persona.Email);
        sw.WriteLine(persona.Telefono);
    }
<<<<<<< HEAD

    public void BajaPersona(int id)
    {
        var personas = ListarPersonas();
        using var sw = new StreamWriter(_nombreArch);
        foreach (var persona in personas)
        {
            if (persona.Id != id)
            {
                sw.WriteLine(persona.Id);
                sw.WriteLine(persona.DNI);
                sw.WriteLine(persona.Nombre);
                sw.WriteLine(persona.Apellido);
                sw.WriteLine(persona.Email);
                sw.WriteLine(persona.Telefono);
            }
        }
    }

    public void ModificarPersona(Persona personaModificada)
    {
        var personas = ListarPersonas();
        using var sw = new StreamWriter(_nombreArch);
        foreach (var persona in personas)
        {
            if (persona.Id == personaModificada.Id)
            {
                sw.WriteLine(personaModificada.Id);
                sw.WriteLine(personaModificada.DNI);
                sw.WriteLine(personaModificada.Nombre);
                sw.WriteLine(personaModificada.Apellido);
                sw.WriteLine(personaModificada.Email);
                sw.WriteLine(personaModificada.Telefono);
            }
            else
            {
                sw.WriteLine(persona.Id);
                sw.WriteLine(persona.DNI);
                sw.WriteLine(persona.Nombre);
                sw.WriteLine(persona.Apellido);
                sw.WriteLine(persona.Email);
                sw.WriteLine(persona.Telefono);
            }
        }
    }

    public List<Persona> ListarPersonas()
    {
        var resultado = new List<Persona>();
        if (!File.Exists(_nombreArch))
            return resultado;
=======
    public List<Persona> ListarPersonas()
    {
        var resultado = new List<Persona>();
>>>>>>> origin/personaNeme
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var persona = new Persona();
<<<<<<< HEAD
            persona.Id = int.Parse(sr.ReadLine()!);
            persona.DNI = sr.ReadLine()!;
            persona.Nombre = sr.ReadLine()!;
            persona.Apellido = sr.ReadLine()!;
            persona.Email = sr.ReadLine()!;
            persona.Telefono = sr.ReadLine()!;
=======
            persona.Id = int.Parse(sr.ReadLine() ?? "");
            persona.DNI = sr.ReadLine() ?? "";
            persona.Nombre = sr.ReadLine() ?? "";
            persona.Apellido = sr.ReadLine() ?? "";
            persona.Email = sr.ReadLine() ?? "";
            persona.Telefono = sr.ReadLine() ?? "";
>>>>>>> origin/personaNeme
            resultado.Add(persona);
        }
        return resultado;
    }
<<<<<<< HEAD
}
=======
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
>>>>>>> origin/personaNeme
