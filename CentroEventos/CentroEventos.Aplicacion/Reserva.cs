namespace CentroEventos.Aplicacion;

public class Reserva
{
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int EventoDeportivoId { get; set; }
    public DateTime FechaAltaReserva { get; set; }
    public Estado EstadoAsistencia { get; set; }

    public enum Estado
    {
        Pendiente,
        Presente,
        Ausente
    }

    public override string ToString()
    {
        return $"Reserva: {Id}, {PersonaId}, {EventoDeportivoId},  {FechaAltaReserva:yyyy-MM-dd HH:mm:ss}, Estado: {EstadoAsistencia}";
    }
}