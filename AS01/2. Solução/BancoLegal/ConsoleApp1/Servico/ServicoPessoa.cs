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
        private Importacao _metaDadoNome;
        private Importacao _metaDadoCpf;
        private Importacao _metaDadoDataNascimento;
        private Importacao _metaDadoEndereco;
        private Importacao _metaDadoId;

        protected override void ConvertaObjetoEmArquivo(Pessoa objeto, StringBuilder stringBuffer)
        {
            stringBuffer
                .Append(objeto.Id.ToString().PadLeft(_metaDadoId.Tamanho, '0'))
                .Append(objeto.Nome.PadRight(_metaDadoNome.Tamanho))
                .Append(objeto.Cpf.PadRight(_metaDadoCpf.Tamanho))
                .Append(objeto.DataNascimento.ToString("dd/MM/yyyy"))
                .Append(objeto.Endereco.PadRight(_metaDadoEndereco.Tamanho));
        }

        protected override string NomeArquivo()
        {
            return "pessoas";
        }

        protected override void PreencheMetaDados()
        {
            _metaDadoNome = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Nome Titular");
            _metaDadoCpf = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Cpf");
            _metaDadoDataNascimento = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Data de Nascimento");
            _metaDadoEndereco = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Endereco");
            _metaDadoId = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Id");
        }

        protected override RepositorioPadrao<Pessoa> Repositorio()
        {
            return _repositorio ?? (_repositorio = new RepositorioPessoa());
        }

        protected override List<Pessoa> RetorneObjetosDeArquivo(List<string> linhas)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            foreach (var linha in linhas)
            {
                Pessoa pessoa = new Pessoa();
                var posicaoInicial = 0;
                pessoa.Id = _utilitarioDeImportacao.ConverteDado(_metaDadoId.Tipo, linha.Substring(0, _metaDadoId.Tamanho).Trim());
                posicaoInicial += _metaDadoId.Tamanho;
                pessoa.Nome = _utilitarioDeImportacao.ConverteDado(_metaDadoNome.Tipo, linha.Substring(posicaoInicial, _metaDadoNome.Tamanho).Trim());
                posicaoInicial += (_metaDadoNome.Tamanho);
                pessoa.Cpf = _utilitarioDeImportacao.ConverteDado(_metaDadoCpf.Tipo, linha.Substring(posicaoInicial, _metaDadoCpf.Tamanho).Trim());
                posicaoInicial += _metaDadoCpf.Tamanho;
                pessoa.DataNascimento = _utilitarioDeImportacao.ConverteDado(_metaDadoDataNascimento.Tipo, linha.Substring(posicaoInicial, _metaDadoDataNascimento.Tamanho).Trim());
                posicaoInicial += _metaDadoDataNascimento.Tamanho;
                pessoa.Endereco = _utilitarioDeImportacao.ConverteDado(_metaDadoEndereco.Tipo, linha.Substring(posicaoInicial, _metaDadoEndereco.Tamanho - 1).Trim());
                pessoas.Add(pessoa);
            }

            return pessoas;
        }
    }
}
