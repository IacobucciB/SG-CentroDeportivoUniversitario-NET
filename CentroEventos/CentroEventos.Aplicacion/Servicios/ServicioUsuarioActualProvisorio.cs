namespace CentroEventos.Aplicacion;

public class ServicioUsuarioActualProvisorio
{
    public Persona? PersonaLogueada { get; private set; }

    public void EstablecerPersona(Persona persona)
    {
        PersonaLogueada = persona;
    }

    public void CerrarSesion()
    {
        PersonaLogueada = null;
    }

    public bool EstaLogueado => PersonaLogueada is not null;
    
}
