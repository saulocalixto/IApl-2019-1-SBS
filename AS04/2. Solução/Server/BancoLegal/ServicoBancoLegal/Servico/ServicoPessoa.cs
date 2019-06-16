using ServicoBancoLegal.BancoDeDados.Repositorio;
using ServicoBancoLegal.Model.PessoaModel;

namespace ServicoBancoLegal.Servico
{
    public class ServicoPessoa : ServicoPadrao<Pessoa>
    {
        protected override RepositorioPadrao<Pessoa> Repositorio()
        {
            return _repositorio ?? (_repositorio = new RepositorioPessoa());
        }
    }
}
