namespace CentroEventos.Aplicacion;

public class EventoDeportivoValidador
{

    public bool Validar(EventoDeportivo eventoDeportivo, out string mensajeError)
    {
        mensajeError = "";

        if (string.IsNullOrWhiteSpace(eventoDeportivo.Nombre))
        {
            mensajeError = "El nombre del evento no puede estar vacío.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(eventoDeportivo.Descripcion))
        {
            mensajeError = "La descripción del evento no puede estar vacía.";
            return false;
        }

        if (eventoDeportivo.FechaHoraInicio < DateTime.Now)
        {
            mensajeError = "La fecha y hora de inicio del evento no puede ser en el pasado.";
            return false;
        }

        if (eventoDeportivo.CupoMaximo <= 0)
        {
            mensajeError = "El cupo máximo del evento debe ser mayor a cero.";
            return false;
        }

        if (eventoDeportivo.DuracionHoras <= 0)
        {
            mensajeError = "La duración del evento debe ser mayor a cero.";
            return false;
        }

        // TODO ResponsableId debe corresponder a una Persona existente

        return (mensajeError == "");
    }

}