namespace CentroEventos.Aplicacion;

public interface IServicioSesion
{
    void IniciarSesion(Persona persona);
    void CerrarSesion();

    Persona? ObtenerPersonaLogueada();
}