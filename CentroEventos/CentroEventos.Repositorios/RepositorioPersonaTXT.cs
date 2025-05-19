namespace CentroEventos.Repositorios;


using CentroEventos.Aplicacion;

public class RepositorioPersonaTXT : IRepositorioPersona
{
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

    public void AgregarPersona(Persona persona)
    {
        persona.Id = ObtenerNuevoId();
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(persona.Id);
        sw.WriteLine(persona.DNI);
        sw.WriteLine(persona.Nombre);
        sw.WriteLine(persona.Apellido);
        sw.WriteLine(persona.Email);
        sw.WriteLine(persona.Telefono);
    }

    public void EliminarPersona(int id)
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
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var persona = new Persona();
            persona.Id = int.Parse(sr.ReadLine()!);
            persona.DNI = sr.ReadLine()!;
            persona.Nombre = sr.ReadLine()!;
            persona.Apellido = sr.ReadLine()!;
            persona.Email = sr.ReadLine()!;
            persona.Telefono = sr.ReadLine()!;
            resultado.Add(persona);
        }
        return resultado;
    }
}
