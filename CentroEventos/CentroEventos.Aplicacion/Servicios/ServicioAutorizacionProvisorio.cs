namespace CentroEventos.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
    {
        return true;
    }
    public bool EsAdmin(int Id)
    {
        return Id >= 30;
    }
}

