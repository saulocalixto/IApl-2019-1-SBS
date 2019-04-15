using BancoLegal.BancoDeDados.Repositorio;
using BancoLegal.Model.OperacaoModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Servico
{
    public class ServicoOperacaoTransferencia : ServicoPadrao<Operacao>
    {
        protected override string NomeArquivo()
        {
            return "operacao";
        }

        protected override RepositorioPadrao<Operacao> Repositorio()
        {
            return _repositorio ?? (_repositorio = new RepositorioOperacao());
        }
    }
}
