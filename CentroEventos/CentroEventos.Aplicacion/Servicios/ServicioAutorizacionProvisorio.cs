namespace CentroEventos.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
    {
        return IdUsuario == 1;
    }
}
/*

public class ServicioAutorizacionProvisorio(AutorizacionException autorizacion) : IServicioAutorizacion
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

*/