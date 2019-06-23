using System;
using ServicoBancoLegal.Model.ContaModel;
using ServicoBancoLegal.Model.OperacaoModel;
using ServicoBancoLegal.Resources;

namespace ServicoBancoLegal.Servico.Utilitario
{
    public class UtilitarioDeOperacoes
    {
        private readonly ContaCorrente _contaOrigem;
        private readonly ContaCorrente _contaDestino;
        private readonly Operacao _operacao;

        private readonly ServicoContaCorrente _servicoContaCorrente;

        public UtilitarioDeOperacoes(Operacao operacao)
        {
            _servicoContaCorrente = new ServicoContaCorrente();
            _operacao = operacao;
            _contaDestino = _servicoContaCorrente.Consulte(_operacao.ContaDestino);
            _contaOrigem = _servicoContaCorrente.Consulte(_operacao.ContaOrigem);
        }

        public bool ApliqueOperacao()
        {
            switch (_operacao.Tipo)
            {
                case EnumTipoOperacao.Saque:
                    return OperacaoDeSaque();
                case EnumTipoOperacao.Deposito:
                    return OperacaoDeDeposito();
                case EnumTipoOperacao.Transferencia:
                    return OperacaoDeTransferencia();
            }

            return false;
        }

        private bool OperacaoDeSaque()
        {
            if ((_contaOrigem.Saldo + _contaOrigem.Limite) >= _operacao.Valor)
            {
                _contaOrigem.Saldo -= _operacao.Valor;
                _servicoContaCorrente.Atualize(_contaOrigem);
                return true;
            }

            throw new Exception(Strings.NotEnoughFunds);
        }

        private bool OperacaoDeDeposito()
        {
            _contaOrigem.Saldo = _contaOrigem.Saldo += _operacao.Valor;
            _servicoContaCorrente.Atualize(_contaOrigem);
            return true;
        }

        private bool OperacaoDeTransferencia()
        {
            if ((_contaOrigem.Saldo + _contaOrigem.Limite) >= _operacao.Valor)
            {
                _contaOrigem.Saldo -= _operacao.Valor;
                _contaDestino.Saldo += _operacao.Valor;
                _servicoContaCorrente.Atualize(_contaOrigem);
                _servicoContaCorrente.Atualize(_contaDestino);
                return true;
            }

            throw new Exception(Strings.NotEnoughFunds);
        }
    }
}
