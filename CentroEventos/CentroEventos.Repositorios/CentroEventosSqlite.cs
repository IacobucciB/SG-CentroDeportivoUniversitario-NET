using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios;

public class CentroEventosSqlite
{
    public static void Inicializar()
    {
        using var context = new CentroEventosContext();

        // Eliminar la base de datos existente
        context.Database.EnsureDeleted();

        // Crear la base de nuevo
        context.Database.EnsureCreated();

        // Abrir la conexión y configurar PRAGMA
        var connection = context.Database.GetDbConnection();
        connection.Open();

        using (var command = connection.CreateCommand())
        {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
        }

        Console.WriteLine("Base de datos reiniciada completamente.");
    }
}
