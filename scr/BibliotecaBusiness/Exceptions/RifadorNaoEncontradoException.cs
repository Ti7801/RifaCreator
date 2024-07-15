namespace BibliotecaBusiness.Exceptions
{
    public class RifadorNaoEncontradoException : Exception
    {
        public RifadorNaoEncontradoException() { }
        public RifadorNaoEncontradoException(string message) : base(message) {}
        public RifadorNaoEncontradoException(string message, Exception e) : base(message, e){}
    }
}
