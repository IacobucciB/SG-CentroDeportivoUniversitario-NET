namespace CentroEventos.Aplicacion;

public class ValidacionException : Exception
{
    public ValidacionException(string message) : base(message)
    {
    }

    public ValidacionException(PersonaValidador validadorPersona, ReservaValidador reservaValidador, EventoDeportivoValidador validadorEvento)
    {
        this.validadorPersona = validadorPersona;
        this.reservaValidador = reservaValidador;
        this.validadorEvento = validadorEvento;
    }

    private readonly PersonaValidador? validadorPersona;
    private readonly ReservaValidador? reservaValidador;
    private readonly EventoDeportivoValidador? validadorEvento;

    public void VerificarPersona(Persona persona)
    {
        if (validadorPersona == null)
            throw new InvalidOperationException("validadorPersona is not initialized.");
        if (!validadorPersona.Validar(persona, out string mensajeError))
        {
            throw new Exception(mensajeError);
        }
    }

    public void VerificarReserva(Reserva reserva)
    {
        if (reservaValidador == null)
            throw new InvalidOperationException("reservaValidador is not initialized.");
        if (!reservaValidador.Validar(reserva, out string mensajeError))
        {
            throw new Exception(mensajeError);
        }
    }

    public void VerificarEvento(EventoDeportivo eventoDeportivo)
    {
        if (validadorEvento == null)
            throw new InvalidOperationException("validadorEvento is not initialized.");
        if (!validadorEvento.Validar(eventoDeportivo, out string mensajeError))
        {
            throw new Exception(mensajeError);
        }
    }
}