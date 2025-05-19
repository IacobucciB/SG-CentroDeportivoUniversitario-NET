namespace CentroEventos.Aplicacion;

public class ValidacionException(PersonaValidador validadorPersona, ReservaValidador reservaValidador, EventoDeportivoValidador validadorEvento)
{
    public void VerificarPersona(Persona persona)
    {
        if (!validadorPersona.Validar(persona, out string mensajeError))
        {
            throw new Exception(mensajeError);
        }
    }

    public void VerificarReserva(Reserva reserva)
    {
        if (!reservaValidador.Validar(reserva,out string mensajeError))
        {
            throw new Exception(mensajeError);
        }
    }

    public void VerificarEvento(EventoDeportivo eventoDeportivo)
    {
        if (!validadorEvento.Validar(eventoDeportivo, out string mensajeError))
        {
            throw new Exception(mensajeError);
        }
    }

}