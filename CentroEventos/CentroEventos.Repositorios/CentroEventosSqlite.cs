using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios;

public class CentroEventosSqlite
{
    public static void Inicializar()
    {
        using var context = new CentroEventosContext();

        if (context.Database.EnsureCreated())
        {

            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
            Console.WriteLine("Se creo la base de datos");
        }
        else
        {
            Console.WriteLine("La base de datos ya existe");
        }

    }

}