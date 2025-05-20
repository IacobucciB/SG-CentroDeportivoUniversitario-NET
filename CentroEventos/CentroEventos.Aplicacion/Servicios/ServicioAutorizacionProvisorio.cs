namespace CentroEventos.Aplicacion;



public class ServicioAutorizacionProvisorio(FalloAutorizacionException autorizacion) : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso) {
        try
        {
            autorizacion.AutorizarExcepciones(IdUsuario);
            return true;
        }
        catch (Exception ex) 
        {
            Console.WriteLine( ex.Message );
        }
        return false;  
    }
}

