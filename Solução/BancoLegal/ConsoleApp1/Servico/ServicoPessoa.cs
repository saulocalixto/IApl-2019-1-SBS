using BancoLegal.Model.PessoaModel;
using BancoLegal.Servico.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BancoLegal.Servico
{
    public class ServicoPessoa : IServico<Pessoa>
    {
        public void CarregaArquivo(string caminhoArquivo)
        {
            //var utilitarioLeitor = new UtilitarioLeitorDeArquivo(caminhoArquivo);
            var utilitarioImportacao = new UtilitarioDeImportacao();

            //var linhas = utilitarioLeitor.RetorneLinhas();

            var linhas = new List<string> { "Saulo Calixto                          0384593011017/09/1990Rua Vitória Régia n 249 Bl b3 Apto 304 " };

            var metaDados = utilitarioImportacao.RetorneMetaDados<Pessoa>();

            var metaDadoNome = metaDados.FirstOrDefault(x => x.NomeCampo == "Nome Titular");
            var metaDadoCpf = metaDados.FirstOrDefault(x => x.NomeCampo == "Cpf");
            var metaDadoDataNascimento = metaDados.FirstOrDefault(x => x.NomeCampo == "Data de Nascimento");
            var metaDadoEndereco = metaDados.FirstOrDefault(x => x.NomeCampo == "Endereco");

            List<Pessoa> pessoas = new List<Pessoa>();

            foreach(var linha in linhas)
            {
                Pessoa pessoa = new Pessoa();
                var posicaoInicial = 0;
                pessoa.Nome = utilitarioImportacao.converteDado(metaDadoNome.Tipo, linha.Substring(0, metaDadoNome.Tamanho - 1).Trim());
                posicaoInicial += (metaDadoNome.Tamanho - 1);
                pessoa.Cpf = utilitarioImportacao.converteDado(metaDadoCpf.Tipo, linha.Substring(posicaoInicial, metaDadoCpf.Tamanho).Trim());
                posicaoInicial += metaDadoCpf.Tamanho;
                pessoa.DataNascimento = utilitarioImportacao.converteDado(metaDadoDataNascimento.Tipo, linha.Substring(posicaoInicial, metaDadoDataNascimento.Tamanho).Trim());
                posicaoInicial += metaDadoDataNascimento.Tamanho;
                pessoa.Endereco = utilitarioImportacao.converteDado(metaDadoEndereco.Tipo, linha.Substring(posicaoInicial, metaDadoEndereco.Tamanho - 1).Trim());
                pessoas.Add(pessoa);
            }

            // TODO gravar lista no banco
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
