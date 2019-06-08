using System;
using ServicoBancoLegal.BancoDeDados.Repositorio;
using ServicoBancoLegal.Model.LoginModel;
using ServicoBancoLegal.Servico.Utilitario;

namespace ServicoBancoLegal.Servico
{
    public class ServicoLogin
    {
        private UtilitarioLeitorDeArquivo _utilitarioLeitor;
        private UtilitarioDeImportacao _utilitarioDeImportacao;
        private RepositorioContaCorrente _repositorioContaCorrente;

        public ServicoLogin()
        {
            _utilitarioDeImportacao = new UtilitarioDeImportacao();
        }

        public bool EfetueLogin(string caminhoArquivo)
        {
            _utilitarioLeitor = new UtilitarioLeitorDeArquivo(caminhoArquivo);

            var linhas = _utilitarioLeitor.RetorneLinhas();

            var objetos = _utilitarioDeImportacao.TransformeLinhaEmObjeto<Login>(linhas);

            foreach (var objeto in objetos)
            {
                var conta = RepositorioContaCorrente().Consulte(objeto.IdConta);
                return conta.Senha.Equals(objeto.Senha);
            }

            return false;
        }

        private RepositorioContaCorrente RepositorioContaCorrente()
        {
            return _repositorioContaCorrente ?? (_repositorioContaCorrente = new RepositorioContaCorrente());
        }

        private string GerarToken(int idPessoa)
        {
            return new Guid().ToString();
        }

        public bool ValidarToken(string token, int idPessoa)
        {
            var t = new Guid();
            return Guid.TryParse(token, out t);
        }
    }
}
