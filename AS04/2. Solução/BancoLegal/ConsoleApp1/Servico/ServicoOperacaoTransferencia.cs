using BancoLegal.BancoDeDados.Repositorio;
using BancoLegal.Model.OperacaoModel;
using BancoLegal.Servico.Utilitario;

namespace BancoLegal.Servico
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
