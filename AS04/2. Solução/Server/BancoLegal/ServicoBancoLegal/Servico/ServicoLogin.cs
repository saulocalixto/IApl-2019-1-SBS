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
            var token = Repositorio().GetToken(sessao.IdConta);

            if (token == Guid.Empty)
            {
                sessao.Token = Guid.NewGuid();
                Repositorio().Cadastre(sessao);
                token = sessao.Token;
            }

            return token;
        }

        public bool TokenIsValid(Guid token)
        {
            return Repositorio().TokenIsValid(token);
        }

        private RepositorioSessao Repositorio()
        {
            return _repositorioSessao ?? (_repositorioSessao = new RepositorioSessao());
        }
    }
}
