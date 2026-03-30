namespace CentroEventos.Aplicacion;

public class FalloAutorizacionException : Exception
{
    public FalloAutorizacionException(string message) : base(message)
    {
    }
    public void AutorizarExcepciones(int IdUsuario)
    {
        if (IdUsuario == 0)
        {
            throw new Exception("El usuario no tiene permisos para realizar esta acción.");
        }
        else
        {
            // Lógica de autorización exitosa
        }
    }
}