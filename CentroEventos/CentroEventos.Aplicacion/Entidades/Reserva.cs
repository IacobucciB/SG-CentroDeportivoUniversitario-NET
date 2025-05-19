namespace CentroEventos.Aplicacion;



public class Reserva
{
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int EventoDeportivoId { get; set; }
    public DateTime FechaAltaReserva { get; set; }
    public EstadoAsistencia EstadoAsistencia { get; set; }

    public override string ToString()
    {
        return $"Reserva Id: {Id}, PersonaId: {PersonaId}, EventoId: {EventoDeportivoId}, Fecha: {FechaAltaReserva}, Estado: {EstadoAsistencia}";
    }
}