using ServicoBancoLegal.BancoDeDados.Repositorio;
using ServicoBancoLegal.Model.OperacaoModel;
using ServicoBancoLegal.Servico.Utilitario;

namespace ServicoBancoLegal.Servico
{
    public class ServicoOperacaoTransferencia : ServicoPadrao<Operacao>
    {
        protected override RepositorioPadrao<Operacao> Repositorio()
        {
            return _repositorio ?? (_repositorio = new RepositorioOperacao());
        }

        public bool ApliqueOperacao(Operacao operacao)
        {
            return (new UtilitarioDeOperacoes(operacao)).ApliqueOperacao();
        }
    }
}
