namespace CentroEventos.Aplicacion;

public class BajaEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo)
{
    public void Ejecutar(int id)
    {
        repositorioEventoDeportivo.BajaEventoDeportivo(id);
    }
}