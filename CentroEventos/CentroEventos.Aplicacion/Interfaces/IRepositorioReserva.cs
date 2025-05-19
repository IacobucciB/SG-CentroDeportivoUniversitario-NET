namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva
{
   void Agregar(Reserva reserva);
    void Modificar(Reserva reserva);
    void Eliminar(int id);
    //Reserva? ObtenerPorId(int id);
    List<Reserva> ListarTodas();
    List<Reserva> ObtenerPorEvento(int eventoId);
    bool ExisteReservaDePersonaEnEvento(int personaId, int eventoId);
}