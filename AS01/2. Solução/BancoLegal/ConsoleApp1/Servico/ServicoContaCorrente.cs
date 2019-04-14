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
        private Importacao _metaDadoTitular;
        private Importacao _metaDadoAgencia;
        private Importacao _metaDadoNumero;
        private Importacao _metaDadoLimite;
        private Importacao _metaDadoSaldo;
        private Importacao _metaDadoSenha;
        private Importacao _metaDadoStatus;
        private Importacao _metaDadoId;

        protected override void ConvertaObjetoEmArquivo(ContaCorrente objeto, StringBuilder stringBuffer)
        {
            stringBuffer.Append(objeto.Id.ToString().PadLeft(_metaDadoId.Tamanho, '0'))
                .Append(objeto.Titular.ToString().PadLeft(_metaDadoTitular.Tamanho, '0'))
                .Append(objeto.Agencia.ToString().PadRight(_metaDadoAgencia.Tamanho))
                .Append(objeto.Numero.ToString().PadRight(_metaDadoNumero.Tamanho))
                .Append(objeto.Senha.ToString().PadRight(_metaDadoSenha.Tamanho))
                .Append(objeto.Saldo.ToString().PadRight(_metaDadoSaldo.Tamanho))
                .Append(objeto.Limite.ToString().PadRight(_metaDadoLimite.Tamanho))
                .Append(objeto.Ativo ? 'S' : 'N');
        }

        protected override string NomeArquivo()
        {
            return "conta";
        }

        protected override void PreencheMetaDados()
        {
            _metaDadoId = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Id");
            _metaDadoTitular = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Titular");
            _metaDadoAgencia = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Agência");
            _metaDadoNumero = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Número");
            _metaDadoSenha = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Senha");
            _metaDadoStatus = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Ativo");
            _metaDadoLimite = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Limite");
            _metaDadoSaldo = _listaMetaDados.FirstOrDefault(x => x.NomeCampo == "Saldo");
        }

        protected override RepositorioPadrao<ContaCorrente> Repositorio()
        {
            return _repositorio ?? (_repositorio = new RepositorioContaCorrente());
        }
    }
}
