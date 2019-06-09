using ServicoBancoLegal.Servico;

namespace ApiBancoLegal.RequestObjects
{
    public class ObjetoRequisicao<T>
    {
        public T objeto;
        public string token;

        public bool IsTokenValido()
        {
            return new ServicoLogin().ValidarToken(token);
        }
    }
}
