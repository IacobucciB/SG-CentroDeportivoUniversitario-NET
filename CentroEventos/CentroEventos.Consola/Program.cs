using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;

// Configuro las dependencias
IRepositorioEventoDeportivo repo = new RepositorioEventoDeportivoTXT();
// Creo los casos de uso
var altaEvento = new AltaEventoDeportivoUseCase(repo);
var listarEventos = new ListarEventosDeportivosUseCase(repo);
// Ejecuto los casos de uso
altaEvento.Ejecutar(new EventoDeportivo() {
    Id = 1,
    Nombre = "Fútbol 5",
    Descripcion = "Torneo de fútbol 5 universitario",
    FechaHoraInicio = DateTime.Now.AddDays(1),
    DuracionHoras = 2,
    CupoMaximo = 10,
    ResponsableId = 1
});
altaEvento.Ejecutar(new EventoDeportivo() {
    Id = 2,
    Nombre = "Básquet",
    Descripcion = "Encuentro amistoso de básquet",
    FechaHoraInicio = DateTime.Now.AddDays(2),
    DuracionHoras = 1.5,
    CupoMaximo = 12,
    ResponsableId = 2
});
var lista = listarEventos.Ejecutar();
foreach (EventoDeportivo e in lista)
{
    Console.WriteLine(e);
}
