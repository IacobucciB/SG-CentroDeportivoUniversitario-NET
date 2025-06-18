using System.Security.Cryptography;
using System.Text;

namespace CentroEventos.Aplicacion;

public class ServicioHash : IServicioHash
{
    public string Hashear(string dato)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(dato);
        var hashBytes = sha256.ComputeHash(bytes);
        return Convert.ToHexString(hashBytes);
    }

    public bool Verificar(string dato, string hashGuardado)
    {
        var hashTextoIngresado = Hashear(dato);
        return hashTextoIngresado.Equals(hashGuardado, StringComparison.OrdinalIgnoreCase);
    }
    
}
