namespace CentroEventos.Aplicacion;

public class ServicioAutorizacionProvisorio(IRepositorioPersona repositorio) : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
    {
        var persona = repositorio.ObtenerPersonaPorId(IdUsuario);
        if (persona == null)
            return false;
        return persona.ListaPermisos.Contains(permiso);
    }
    public bool EsAdmin(int Id)
    {
        return Id == 1;
    }
}

