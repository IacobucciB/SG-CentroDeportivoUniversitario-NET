namespace CentroEventos.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool EsAdmin(int IdUsuario)
    {
        return IdUsuario == 1;
    }
    /*
    public bool PoseePermiso(int IdUsuario, Permiso permiso) {

        return
    }
    */
}

