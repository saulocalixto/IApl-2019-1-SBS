using BancoLegal.BancoDeDados.Repositorio;
using BancoLegal.Model.ContaModel;
using BancoLegal.Model.DataAnnotations;
using BancoLegal.Servico.Utilitario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
