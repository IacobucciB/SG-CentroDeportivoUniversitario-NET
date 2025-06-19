namespace CentroEventos.Aplicacion
{
    public class OperacionInvalidaException : Exception
    {
        public OperacionInvalidaException() { }

        public OperacionInvalidaException(string mensaje) : base(mensaje) { }

        public OperacionInvalidaException(string mensaje, Exception inner) : base(mensaje, inner) { }
    }
}