namespace BibliotecaBusiness.Exceptions
{
    public class BilheteNaoEncontradoException : Exception
    {
        public BilheteNaoEncontradoException() { }  
        public BilheteNaoEncontradoException(string message) : base(message) { }
        public BilheteNaoEncontradoException(string message, Exception e) : base(message, e){}
    }
}
