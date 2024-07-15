namespace BibliotecaBusiness.Exceptions
{
    public class RifaNaoEncontradaException : Exception 
    {
        public RifaNaoEncontradaException() { }
        public RifaNaoEncontradaException(string message) : base(message) { }
        public RifaNaoEncontradaException(string message, Exception e ) : base(message, e) { }
    }
}
