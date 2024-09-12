namespace BibliotecaBusiness.Exceptions
{
    public class AfiliadoNaoEncontradoException : Exception
    {
        public AfiliadoNaoEncontradoException() { }
        public AfiliadoNaoEncontradoException(string messege): base(messege) { }
        public AfiliadoNaoEncontradoException(string messege, Exception e): base(messege, e) { }
    }
}
