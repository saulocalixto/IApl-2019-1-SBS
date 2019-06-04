using BancoLegal.BancoDeDados.Repositorio;
using BancoLegal.Model.ContaModel;

namespace BancoLegal.Servico
{
    public class ServicoContaCorrente : ServicoPadrao<ContaCorrente>
    {
        protected override string NomeArquivo()
        {
            return "conta";
        }

        protected override RepositorioPadrao<ContaCorrente> Repositorio()
        {
            return _repositorio ?? (_repositorio = new RepositorioContaCorrente());
        }
    }
}
