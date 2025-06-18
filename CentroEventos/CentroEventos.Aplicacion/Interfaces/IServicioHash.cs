namespace CentroEventos.Aplicacion;

public interface IServicioHash
{
    public string Hashear(string dato);

    public bool Verificar(string dato, string hash);
}
