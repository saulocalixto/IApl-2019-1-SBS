using BancoLegal.Model.ContaModel;
using BancoLegal.Model.DataAnnotations;
using BancoLegal.Servico.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BancoLegal.Servico
{
    class ServicoContaCorrente : IServico<ContaCorrente>
    {
        private IList<Importacao> _listaMetaDados;
        private Importacao _metaDadoTitular;
        private Importacao _metaDadoAgencia;
        private Importacao _metaDadoNumero;
        private Importacao _metaDadoLimite;
        private Importacao _metaDadoSaldo;
        private Importacao _metaDadoSenha;
        private Importacao _metaDadoStatus;
        private Importacao _metaDadoId;

        private UtilitarioDeImportacao _utilitarioDeImportacao;

        public ServicoContaCorrente()
        {
            _utilitarioDeImportacao = new UtilitarioDeImportacao();
            _listaMetaDados = _utilitarioDeImportacao.RetorneMetaDados<ContaCorrente>();

            _metaDadoId = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Id");
            _metaDadoTitular = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Titular");
            _metaDadoAgencia = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Agência");
            _metaDadoNumero = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Número");
            _metaDadoSenha = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Senha");
            _metaDadoStatus = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Ativo");
            _metaDadoLimite = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Limite");
            _metaDadoSaldo = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Saldo");
        }

        public void CarregaArquivo(string caminhoArquivo)
        {
            var utilitarioLeitor = new UtilitarioLeitorDeArquivo(caminhoArquivo);

            var linhas = utilitarioLeitor.RetorneLinhas();

            List<ContaCorrente> pessoas = new List<ContaCorrente>();

            foreach (var linha in linhas)
            {
                ContaCorrente conta = new ContaCorrente();
                var posicaoInicial = 0;
                conta.Id = _utilitarioDeImportacao.converteDado(_metaDadoId.Tipo, linha.Substring(0, _metaDadoId.Tamanho).Trim());
                posicaoInicial += _metaDadoId.Tamanho;
                conta.Titular = _utilitarioDeImportacao.converteDado(_metaDadoTitular.Tipo, linha.Substring(posicaoInicial, _metaDadoTitular.Tamanho).Trim());
                posicaoInicial += (_metaDadoTitular.Tamanho);
                conta.Agencia = _utilitarioDeImportacao.converteDado(_metaDadoAgencia.Tipo, linha.Substring(posicaoInicial, _metaDadoAgencia.Tamanho).Trim());
                posicaoInicial += _metaDadoAgencia.Tamanho;
                conta.Numero = _utilitarioDeImportacao.converteDado(_metaDadoNumero.Tipo, linha.Substring(posicaoInicial, _metaDadoNumero.Tamanho).Trim());
                posicaoInicial += _metaDadoNumero.Tamanho;
                conta.Senha = _utilitarioDeImportacao.converteDado(_metaDadoSenha.Tipo, linha.Substring(posicaoInicial, _metaDadoSenha.Tamanho - 1).Trim());
                posicaoInicial += _metaDadoSenha.Tamanho;
                conta.Saldo = _utilitarioDeImportacao.converteDado(_metaDadoSaldo.Tipo, linha.Substring(posicaoInicial, _metaDadoSaldo.Tamanho - 1).Trim());
                posicaoInicial += _metaDadoSaldo.Tamanho;
                conta.Limite = _utilitarioDeImportacao.converteDado(_metaDadoLimite.Tipo, linha.Substring(posicaoInicial, _metaDadoLimite.Tamanho - 1).Trim());
                posicaoInicial += _metaDadoLimite.Tamanho;
                conta.Ativo = _utilitarioDeImportacao.converteDado(_metaDadoStatus.Tipo, linha.Substring(posicaoInicial, _metaDadoStatus.Tamanho - 1).Trim());
                pessoas.Add(conta);
            }
        }

        public string Consulte(int Id)
        {
            var conta = new ContaCorrente
            {
                Id = 1,
                Agencia = 3536,
                Numero = 45216,
                Limite = 50000.00,
                Saldo = 300.22,
                Senha = 4546,
                Ativo = true,
                Titular = 1
            };

            var stringBuffer = new StringBuilder();

            stringBuffer.Append(conta.Id.ToString().PadLeft(_metaDadoId.Tamanho, '0'))
                .Append(conta.Titular.ToString().PadLeft(_metaDadoTitular.Tamanho, '0'))
                .Append(conta.Agencia.ToString().PadRight(_metaDadoAgencia.Tamanho))
                .Append(conta.Numero.ToString().PadRight(_metaDadoNumero.Tamanho))
                .Append(conta.Senha.ToString().PadRight(_metaDadoSenha.Tamanho))
                .Append(conta.Saldo.ToString().PadRight(_metaDadoSaldo.Tamanho))
                .Append(conta.Limite.ToString().PadRight(_metaDadoLimite.Tamanho))
                .Append(conta.Ativo ? 'S' : 'N');

            return stringBuffer.ToString();
        }

        public string EmiteLayout()
        {
            throw new NotImplementedException();
        }
    }
}
