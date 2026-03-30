namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion;

public class RepositorioEventoDeportivoTXT : IRepositorioEventoDeportivo
{
    readonly string _nombreArch = "eventoDeportivo.txt";

    private int ObtenerNuevoId()
    {
        int maxId = 0;
        if (File.Exists(_nombreArch))
            using (var sr = new StreamReader(_nombreArch))
                while (!sr.EndOfStream)
                {
                    if (int.TryParse(sr.ReadLine(), out int id) && id > maxId) maxId = id;
                    for (int i = 0; i < 6 && !sr.EndOfStream; i++) sr.ReadLine();
                }
        return maxId + 1;
    }

    public void AltaEventoDeportivo(EventoDeportivo eventoDeportivo)
    {
        if (eventoDeportivo.Id == 0)
        {
            eventoDeportivo.Id = ObtenerNuevoId();
        }
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(eventoDeportivo.Id);
        sw.WriteLine(eventoDeportivo.Nombre);
        sw.WriteLine(eventoDeportivo.Descripcion);
        sw.WriteLine(eventoDeportivo.FechaHoraInicio);
        sw.WriteLine(eventoDeportivo.DuracionHoras);
        sw.WriteLine(eventoDeportivo.CupoMaximo);
        sw.WriteLine(eventoDeportivo.ResponsableId);
    }
    public void BajaEventoDeportivo(int id)
    {
        var eventos = ListarEventosDeportivos();
        using var sw = new StreamWriter(_nombreArch);
        foreach (var evento in eventos)
        {
            if (evento.Id != id)
            {
                sw.WriteLine(evento.Id);
                sw.WriteLine(evento.Nombre);
                sw.WriteLine(evento.Descripcion);
                sw.WriteLine(evento.FechaHoraInicio);
                sw.WriteLine(evento.DuracionHoras);
                sw.WriteLine(evento.CupoMaximo);
                sw.WriteLine(evento.ResponsableId);
            }
        }
    }
    public void ModificarEventoDeportivo(EventoDeportivo eventoDeportivo)
    {
        var eventos = ListarEventosDeportivos();
        using var sw = new StreamWriter(_nombreArch);
        foreach (var evento in eventos)
        {
            if (evento.Id == eventoDeportivo.Id)
            {
                sw.WriteLine(eventoDeportivo.Id);
                sw.WriteLine(eventoDeportivo.Nombre);
                sw.WriteLine(eventoDeportivo.Descripcion);
                sw.WriteLine(eventoDeportivo.FechaHoraInicio);
                sw.WriteLine(eventoDeportivo.DuracionHoras);
                sw.WriteLine(eventoDeportivo.CupoMaximo);
                sw.WriteLine(eventoDeportivo.ResponsableId);
            }
            else
            {
                sw.WriteLine(evento.Id);
                sw.WriteLine(evento.Nombre);
                sw.WriteLine(evento.Descripcion);
                sw.WriteLine(evento.FechaHoraInicio);
                sw.WriteLine(evento.DuracionHoras);
                sw.WriteLine(evento.CupoMaximo);
                sw.WriteLine(evento.ResponsableId);
            }
        }
    }
    public List<EventoDeportivo> ListarEventosDeportivos()
    {
        var resultado = new List<EventoDeportivo>();
        if (!File.Exists(_nombreArch))
        {
            return resultado;
        }
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var eventoDeportivo = new EventoDeportivo();
            eventoDeportivo.Id = int.Parse(sr.ReadLine()!);
            eventoDeportivo.Nombre = sr.ReadLine()!;
            eventoDeportivo.Descripcion = sr.ReadLine()!;
            eventoDeportivo.FechaHoraInicio = DateTime.Parse(sr.ReadLine()!);
            eventoDeportivo.DuracionHoras = double.Parse(sr.ReadLine()!);
            eventoDeportivo.CupoMaximo = int.Parse(sr.ReadLine()!);
            eventoDeportivo.ResponsableId = int.Parse(sr.ReadLine()!);
            resultado.Add(eventoDeportivo);
        }
        return resultado;

    }

    public EventoDeportivo? ObtenerEventoDeportivoPorId(int id)
    {
        var eventos = ListarEventosDeportivos();
        return eventos.FirstOrDefault(e => e.Id == id);
    }
}