using ServicoBancoLegal.BancoDeDados.Repositorio;
using ServicoBancoLegal.Model.ContaModel;

namespace ServicoBancoLegal.Servico
{
    public class ServicoContaCorrente : ServicoPadrao<ContaCorrente>
    {
        protected override RepositorioPadrao<ContaCorrente> Repositorio()
        {
            return _repositorio ?? (_repositorio = new RepositorioContaCorrente());
        }

        public int ConsulteIdDaConta(string senha, string email)
        {
            return ((RepositorioContaCorrente)Repositorio()).RetorneIdDaConta(senha, email);
        }
    }
}
