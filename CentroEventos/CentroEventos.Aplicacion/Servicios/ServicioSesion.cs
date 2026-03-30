namespace CentroEventos.Aplicacion;

public class ServicioSesion() : IServicioSesion
{
    public Persona? PersonaLogueada { get; private set; }

    public event Action? OnSesionCambiada;

    public void IniciarSesion(Persona persona)
    {
        PersonaLogueada = persona;
        OnSesionCambiada?.Invoke();
    }

    public void CerrarSesion()
    {
        PersonaLogueada = null;
        OnSesionCambiada?.Invoke();
    }

    public Persona? ObtenerPersonaLogueada() => PersonaLogueada;
    
}
