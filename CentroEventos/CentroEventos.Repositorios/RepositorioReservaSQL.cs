using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios
{
    public class RepositorioReservaSQL : IRepositorioReserva
    {
        public void AltaReserva(Reserva reserva)
        {
            using var CentroEventosContext = new CentroEventosContext();
            CentroEventosContext.Reservas.Add(reserva);
            CentroEventosContext.SaveChanges();
        }

        public void ModificarReserva(Reserva reserva)
        {
            using var CentroEventosContext = new CentroEventosContext();
            CentroEventosContext.Reservas.Update(reserva);
            CentroEventosContext.SaveChanges();
        }

        public void BajaReserva(int id)
        {
            using var CentroEventosContext = new CentroEventosContext();
            var reserva = CentroEventosContext.Reservas.Find(id);
            if (reserva != null)
            {
                CentroEventosContext.Reservas.Remove(reserva);
                CentroEventosContext.SaveChanges();
            }
        }

        public List<Reserva> ListarReservas()
        {
            using var CentroEventosContext = new CentroEventosContext();
            return CentroEventosContext.Reservas.ToList();
        }

        public Reserva? GetReserva(int id)
        {
            using var CentroEventosContext = new CentroEventosContext();
            return CentroEventosContext.Reservas.Find(id);
        }
        public List<Reserva> ListarReservasPorEvento(int eventoId)
        {
            using var CentroEventosContext = new CentroEventosContext();
            return CentroEventosContext.Reservas
                .Where(r => r.EventoDeportivoId == eventoId)
                .ToList();
        }
        public bool ExisteReserva(int personaId, int eventoId)
        {
            using var CentroEventosContext = new CentroEventosContext();
            return CentroEventosContext.Reservas
                .Any(r => r.PersonaId == personaId && r.EventoDeportivoId == eventoId);
        }
        public Reserva? ObtenerReservaPorId(int id)
        {
            using var CentroEventosContext = new CentroEventosContext();
            return CentroEventosContext.Reservas.Find(id);
        }
    }
}