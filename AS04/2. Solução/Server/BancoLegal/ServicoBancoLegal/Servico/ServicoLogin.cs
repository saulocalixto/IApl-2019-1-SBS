using ServicoBancoLegal.BancoDeDados.Repositorio;
using ServicoBancoLegal.Model.LoginModel;
using ServicoBancoLegal.Servico.Utilitario;
using System;

namespace ServicoBancoLegal.Servico
{
    public class ServicoLogin
    {
        private RepositorioSessao _repositorioSessao;

        public Guid EfetueLogin(Sessao sessao)
        {
            var token = Repository().GetToken(sessao.IdConta);

            if (token == Guid.Empty)
            {
                sessao.Token = Guid.NewGuid();
                Repository().Insert(sessao);
                token = sessao.Token;
            }

            return token;
        }

        public bool TokenIsValid(Guid token)
        {
            return Repository().TokenIsValid(token);
        }

        private RepositorioSessao Repository()
        {
            return _repositorioSessao ?? (_repositorioSessao = new RepositorioSessao());
        }
    }
}
