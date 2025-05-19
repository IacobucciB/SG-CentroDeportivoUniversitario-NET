namespace CentroEventos.Aplicacion;

public class BajaReservaUseCase(IRepositorioReserva repositorioReserva)
{
    public void Ejecutar(int id)
    {
        repositorioReserva.BajaReserva(id);
    }
}