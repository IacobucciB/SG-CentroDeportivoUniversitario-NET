namespace CentroEventos.Aplicacion;

public class EventoDeportivo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public DateTime FechaHoraInicio { get; set; }
    public double DuracionHoras { get; set; }
    public int CupoMaximo { get; set; }
    public int ResponsableId { get; set; }

    public override string ToString()
    {
        return $"EventoDeportivo: {Id}, {Nombre}, {Descripcion}, {FechaHoraInicio:yyyy-MM-dd HH:mm:ss}, {DuracionHoras}, {CupoMaximo}, {ResponsableId}";
    }
}