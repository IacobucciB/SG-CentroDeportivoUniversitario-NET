namespace CentroEventos.Aplicacion.Validadores
{
    public class ValidadorReserva
    {
        private readonly IRepositorioPersona _repoPersona;
        private readonly IRepositorioEventoDeportivo _repoEvento;
        private readonly IRepositorioReserva _repoReserva;

        //Son los constructores
        public ValidadorReserva(
            IRepositorioPersona repoPersona,
            IRepositorioEventoDeportivo repoEvento,
            IRepositorioReserva repoReserva)
        {
            _repoPersona = repoPersona;
            _repoEvento = repoEvento;
            _repoReserva = repoReserva;
        }

        public void Validar(Reserva reserva)
        {
            // 1. Validar que exista la persona (tengo que ver que hizo lauti)
            var persona = _repoPersona.ObtenerPorId(reserva.PersonaId);
            if (persona == null)
                throw new EntidadNotFoundException("La persona no existe.");

            // 2. Validar que exista el evento (Tengo que ver que hizo bauti)
            var evento = _repoEvento.ObtenerPorId(reserva.EventoDeportivoId);
            if (evento == null)
                throw new EntidadNotFoundException("El evento deportivo no existe.");

            // 3. Validar que la persona no tenga ya una reserva en ese evento
            if (_repoReserva.ExisteReserva(reserva.PersonaId, reserva.EventoDeportivoId))
                throw new DuplicadoException("La persona ya tiene una reserva para este evento.");

            // 4. Validar que haya cupo disponible
            var reservas = _repoReserva.ListarReservasPorEvento(reserva.EventoDeportivoId);
            if (reservas.Count >= evento.CupoMaximo)
                throw new CupoExcedidoException("No hay cupo disponible para este evento.");
        }
    }
}
