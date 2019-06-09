using ServicoBancoLegal.BancoDeDados.Repositorio;
using ServicoBancoLegal.Model.LoginModel;
using ServicoBancoLegal.Servico.Utilitario;
using System;

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

        public bool EfetueLogin(Login objeto)
        {
            var conta = RepositorioContaCorrente().Consulte(objeto.IdConta);
            return conta.Senha.Equals(objeto.Senha);
        }

        private RepositorioContaCorrente RepositorioContaCorrente()
        {
            return _repositorioContaCorrente ?? (_repositorioContaCorrente = new RepositorioContaCorrente());
        }

        public string GerarToken(int idPessoa)
        {
            return Guid.NewGuid().ToString();
        }

        public bool ValidarToken(string token)
        {
            var t = new Guid();
            return Guid.TryParse(token, out t);
        }
    }
}
