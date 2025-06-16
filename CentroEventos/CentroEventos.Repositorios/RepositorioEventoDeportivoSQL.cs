using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios
{
    public class RepositorioEventoDeportivoSQL : IRepositorioEventoDeportivo
    {
        public void AltaEventoDeportivo(EventoDeportivo eventoDeportivo)
        {
            using var CentroEventosContext = new CentroEventosContext();
            CentroEventosContext.EventosDeportivos.Add(eventoDeportivo);
            CentroEventosContext.SaveChanges();
        }

        public void ModificarEventoDeportivo(EventoDeportivo eventoDeportivo)
        {
            using var CentroEventosContext = new CentroEventosContext();
            CentroEventosContext.EventosDeportivos.Update(eventoDeportivo);
            CentroEventosContext.SaveChanges();
        }

        public void BajaEventoDeportivo(int id)
        {
            using var CentroEventosContext = new CentroEventosContext();
            var evento = CentroEventosContext.EventosDeportivos.Find(id);
            if (evento != null)
            {
                CentroEventosContext.EventosDeportivos.Remove(evento);
                CentroEventosContext.SaveChanges();
            }
        }

        public List<EventoDeportivo> ListarEventosDeportivos()
        {
            using var CentroEventosContext = new CentroEventosContext();
            return CentroEventosContext.EventosDeportivos.ToList();
        }

        public EventoDeportivo? GetEventoDeportivo(int id)
        {
            using var CentroEventosContext = new CentroEventosContext();
            return CentroEventosContext.EventosDeportivos.Find(id);
        }
    }
}