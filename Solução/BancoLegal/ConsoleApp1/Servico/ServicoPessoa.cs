using BancoLegal.Model.DataAnnotations;
using BancoLegal.Model.PessoaModel;
using BancoLegal.Servico.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BancoLegal.Servico
{
    public class ServicoPessoa : IServico<Pessoa>
    {
        private IList<Importacao> _listaMetaDados;
        private Importacao _metaDadoNome;
        private Importacao _metaDadoCpf;
        private Importacao _metaDadoDataNascimento;
        private Importacao _metaDadoEndereco;

        private UtilitarioDeImportacao _utilitarioDeImportacao;

        public ServicoPessoa()
        {
            _utilitarioDeImportacao = new UtilitarioDeImportacao();
            _listaMetaDados = _utilitarioDeImportacao.RetorneMetaDados<Pessoa>();

            _metaDadoNome = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Nome Titular");
            _metaDadoCpf = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Cpf");
            _metaDadoDataNascimento = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Data de Nascimento");
            _metaDadoEndereco = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Endereco");
        }

        public void CarregaArquivo(string caminhoArquivo)
        {
            var utilitarioLeitor = new UtilitarioLeitorDeArquivo(caminhoArquivo);

            var linhas = utilitarioLeitor.RetorneLinhas();

            List<Pessoa> pessoas = new List<Pessoa>();

            foreach (var linha in linhas)
            {
                Pessoa pessoa = new Pessoa();
                var posicaoInicial = 0;
                pessoa.Nome = _utilitarioDeImportacao.converteDado(_metaDadoNome.Tipo, linha.Substring(0, _metaDadoNome.Tamanho).Trim());
                posicaoInicial += (_metaDadoNome.Tamanho);
                pessoa.Cpf = _utilitarioDeImportacao.converteDado(_metaDadoCpf.Tipo, linha.Substring(posicaoInicial, _metaDadoCpf.Tamanho).Trim());
                posicaoInicial += _metaDadoCpf.Tamanho;
                pessoa.DataNascimento = _utilitarioDeImportacao.converteDado(_metaDadoDataNascimento.Tipo, linha.Substring(posicaoInicial, _metaDadoDataNascimento.Tamanho).Trim());
                posicaoInicial += _metaDadoDataNascimento.Tamanho;
                pessoa.Endereco = _utilitarioDeImportacao.converteDado(_metaDadoEndereco.Tipo, linha.Substring(posicaoInicial, _metaDadoEndereco.Tamanho - 1).Trim());
                pessoas.Add(pessoa);
            }

            // TODO gravar lista no banco
        }

        public string Consulte(int Id)
        {

            //TODO consultar a pessoa e transformá-la em um arquivo txt e retornar para o usuário.

            var pessoa = new Pessoa
            {
                Nome = "Saulo Calixto",
                Cpf = "03845930110",
                DataNascimento = DateTime.Now,
                Endereco = "Ruas das orquídias num bairro orquideoso"
            };

            var stringBuffer = new StringBuilder();
            stringBuffer.Append(pessoa.Nome.PadRight(_metaDadoNome.Tamanho))
                .Append(pessoa.Cpf.PadRight(_metaDadoCpf.Tamanho))
                .Append(pessoa.DataNascimento.ToString("dd/MM/yyyy"))
                .Append(pessoa.Endereco.PadRight(_metaDadoEndereco.Tamanho));

            return stringBuffer.ToString();
        }

        public string EmiteLayout()
        {
            // TODO MontarLayout
            throw new NotImplementedException();
        }
    }
}
