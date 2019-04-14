using BancoLegal.BancoDeDados.Repositorio;
using BancoLegal.Model.DataAnnotations;
using BancoLegal.Model.PessoaModel;
using BancoLegal.Servico.Utilitario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BancoLegal.Servico
{
    public class ServicoPessoa : ServicoPadrao<Pessoa>
    {
        protected override string NomeArquivo()
        {
            return "pessoas";
        }

        protected override RepositorioPadrao<Pessoa> Repositorio()
        {
            return _repositorio ?? (_repositorio = new RepositorioPessoa());
        }
    }
}
