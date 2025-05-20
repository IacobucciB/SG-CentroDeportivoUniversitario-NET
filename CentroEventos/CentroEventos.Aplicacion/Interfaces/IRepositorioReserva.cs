namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva
{
    void AltaReserva(Reserva reserva);
    void BajaReserva(int id);
    void ModificarReserva(Reserva reserva);
    List<Reserva> ListarReservas();
    List<Reserva> ListarReservasPorEvento(int eventoId);
    bool ExisteReserva(int personaId, int eventoId);
    Reserva? ObtenerReservaPorId(int id);

    int eventoid(int eventioId);
}