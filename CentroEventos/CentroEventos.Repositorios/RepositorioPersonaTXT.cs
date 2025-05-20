using CentroEventos.Aplicacion;


namespace CentroEventos.Repositorios
{
        public class RepositorioPersonaTXT : IRepositorioPersona
        {
            private readonly string _archivo = "personas.txt";
            private int _ultimoId;

            public RepositorioPersonaTXT()
            {
                if (!File.Exists(_archivo))
                    File.Create(_archivo).Close();

                _ultimoId = ObtenerUltimoId();
            }

            private int ObtenerUltimoId()
            {
                var lineas = File.ReadAllLines(_archivo);
                int maxId = 0;
                for (int i = 0; i < lineas.Length; i += 6)
                {
                    if (int.TryParse(lineas[i], out int id) && id > maxId)
                        maxId = id;
                }
                return maxId;
            }

            public void AgregarPersona(Persona persona)
            {
                _ultimoId++;
                persona.Id = _ultimoId;

                using var sw = new StreamWriter(_archivo, append: true);
                sw.WriteLine(persona.Id);
                sw.WriteLine(persona.DNI);
                sw.WriteLine(persona.Nombre);
                sw.WriteLine(persona.Apellido);
                sw.WriteLine(persona.Email);
                sw.WriteLine(persona.Telefono);
            }

            public void ModificarPersona(Persona persona)
            {
                var personas = ListarPersonas();
                var index = personas.FindIndex(p => p.Id == persona.Id);
                if (index >= 0)
                {
                    personas[index] = persona;
                    GuardarTodo(personas);
                }
            }

            public void EliminarPersona(int id)
            {
                var personas = ListarPersonas();
                personas.RemoveAll(p => p.Id == id);
                GuardarTodo(personas);
            }

            public List<Persona> ListarPersonas()
            {
                var personas = new List<Persona>();
                var lineas = File.ReadAllLines(_archivo);

                for (int i = 0; i < lineas.Length; i += 6)
                {
                    var persona = new Persona
                    {
                        Id = int.Parse(lineas[i]),
                        DNI = lineas[i + 1],
                        Nombre = lineas[i + 2],
                        Apellido = lineas[i + 3],
                        Email = lineas[i + 4],
                        Telefono = lineas[i + 5]
                    };
                    personas.Add(persona);
                }

                return personas;
            }

            public Persona? GetPersona(int id)
            {
                return ListarPersonas().FirstOrDefault(p => p.Id == id);
            }

            private void GuardarTodo(List<Persona> personas)
            {
                using var sw = new StreamWriter(_archivo, append: false);
                foreach (var p in personas)
                {
                    sw.WriteLine(p.Id);
                    sw.WriteLine(p.DNI);
                    sw.WriteLine(p.Nombre);
                    sw.WriteLine(p.Apellido);
                    sw.WriteLine(p.Email);
                    sw.WriteLine(p.Telefono);
                }
            }

        }
    }
