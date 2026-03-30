namespace CentroEventos.Aplicacion;

public interface IServicioAutorizacion
{
    bool PoseeElPermiso(int IdUsuario, Permiso permiso);
    bool EsAdmin(int Id);
}