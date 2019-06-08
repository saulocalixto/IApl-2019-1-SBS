using System;

namespace ApiBancoLegal.Exceptions
{
    public class ObjetoErro
    {
        public string mensagem;
        public string stackTrace;

        public ObjetoErro(Exception e)
        {
            mensagem = e.Message;
            stackTrace = e.StackTrace;
        }
    }
}
