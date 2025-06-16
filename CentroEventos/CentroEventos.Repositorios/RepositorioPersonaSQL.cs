using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios
{
    public class RepositorioPersonaSQL : IRepositorioPersona
    {
        public void AgregarPersona(Persona persona)
        {
            using var CentroEventosContext = new CentroEventosContext();
            CentroEventosContext.Personas.Add(persona);
            CentroEventosContext.SaveChanges();
        }
        public void ModificarPersona(Persona persona)
        {
            using var CentroEventosContext = new CentroEventosContext();
            CentroEventosContext.Personas.Update(persona);
            CentroEventosContext.SaveChanges();
        }
        public void EliminarPersona(int id)
        {
            using var CentroEventosContext = new CentroEventosContext();
            var persona = CentroEventosContext.Personas.Find(id);
            if (persona != null)
            {
                CentroEventosContext.Personas.Remove(persona);
                CentroEventosContext.SaveChanges();
            }
        }
        public List<Persona> ListarPersonas()
        {
            using var CentroEventosContext = new CentroEventosContext();
            return CentroEventosContext.Personas.ToList();
        }
        public Persona? GetPersona(int id)
        {
            using var CentroEventosContext = new CentroEventosContext();
            return CentroEventosContext.Personas.Find(id);
        }
    }
}