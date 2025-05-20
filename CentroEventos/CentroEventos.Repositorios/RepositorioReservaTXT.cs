using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios
{
    public class RepositorioReservaTXT : IRepositorioReserva
    {
        readonly string _archivo = "reservas.txt";
        private int _ultimoId;

        public RepositorioReservaTXT()
        {
            if (!File.Exists(_archivo))
                File.Create(_archivo).Close();

            _ultimoId = ObtenerUltimoId();
        }

        private int ObtenerUltimoId()
        {
            var lineas = File.ReadAllLines(_archivo);
            int maxId = 0;
            for (int i = 0; i < lineas.Length; i += 5)
            {
                if (int.TryParse(lineas[i], out int id))
                    if (id > maxId) maxId = id;
            }
            return maxId;
        }

        public void AltaReserva(Reserva reserva)
        {
            _ultimoId++;
            reserva.Id = _ultimoId;
            using var sw = new StreamWriter(_archivo, append: true);
            sw.WriteLine(reserva.Id);
            sw.WriteLine(reserva.PersonaId);
            sw.WriteLine(reserva.EventoDeportivoId);
            sw.WriteLine(reserva.FechaAltaReserva.ToString("o"));
            sw.WriteLine(reserva.EstadoAsistencia); // Se guarda como texto (ej: Pendiente)
        }

        public void BajaReserva(int id)
        {
            var reservas = ListarReservas();
            reservas.RemoveAll(r => r.Id == id);
            GuardarTodo(reservas);
        }

        public void ModificarReserva(Reserva reserva)
        {
            var reservas = ListarReservas();
            var i = reservas.FindIndex(r => r.Id == reserva.Id);
            if (i >= 0)
            {
                reservas[i] = reserva;
                GuardarTodo(reservas);
            }
        }

        public List<Reserva> ListarReservas()
        {
            var reservas = new List<Reserva>();
            if (!File.Exists(_archivo)) return reservas;

            var lineas = File.ReadAllLines(_archivo);
            for (int i = 0; i < lineas.Length; i += 5)
            {
                var reserva = new Reserva
                {
                    Id = int.Parse(lineas[i]),
                    PersonaId = int.Parse(lineas[i + 1]),
                    EventoDeportivoId = int.Parse(lineas[i + 2]),
                    FechaAltaReserva = DateTime.Parse(lineas[i + 3]),
                    EstadoAsistencia = Enum.Parse<EstadoAsistencia>(lineas[i + 4])
                };
                reservas.Add(reserva);
            }
            return reservas;
        }

        public Reserva? ObtenerReservaPorId(int id)
        {
            var reservas = ListarReservas(); // Usa la función que lee todas las reservas
            return reservas.FirstOrDefault(r => r.Id == id);
        }
        private void GuardarTodo(List<Reserva> reservas)
        {
            using var sw = new StreamWriter(_archivo, append: false);
            foreach (var r in reservas)
            {
                sw.WriteLine(r.Id);
                sw.WriteLine(r.PersonaId);
                sw.WriteLine(r.EventoDeportivoId);
                sw.WriteLine(r.FechaAltaReserva.ToString("o"));
                sw.WriteLine(r.EstadoAsistencia);
            }
        }

        public int eventoid(int id)
        {
            var reservas = ListarReservas(); // Usa la función que lee todas las reservas
            return reservas.FirstOrDefault(r => r.Id == id);

        }
    }
}