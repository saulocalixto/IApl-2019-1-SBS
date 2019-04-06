using BancoLegal.Model.PessoaModel;
using BancoLegal.Servico.Utilitario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BancoLegal.Servico
{
    public class ServicoPessoa : IServico<Pessoa>
    {
        public void CarregaArquivo(string caminhoArquivo)
        {
            var utilitarioLeitor = new UtilitarioLeitorDeArquivo(caminhoArquivo);

            var linhas = utilitarioLeitor.RetorneLinhas();

            // TODO montar objeto e depois salvá-lo no banco.
        }

        public Pessoa Consulte(string Id)
        {
            throw new NotImplementedException();
        }

        public string EmiteLayout()
        {
            throw new NotImplementedException();
        }
    }
}
