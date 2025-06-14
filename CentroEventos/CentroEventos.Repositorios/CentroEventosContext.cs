using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class CentroEventosContext : DbContext
{
    public DbSet<Persona> Personas { get; set; }
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=CentroEventos.db");
    }

}