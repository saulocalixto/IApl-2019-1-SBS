using BancoLegal.Model.ContaModel;
using BancoLegal.Model.OperacaoModel;
using System;

namespace BancoLegal.Servico.Utilitario
{
    public class UtilitarioDeOperacoes
    {
        private ContaCorrente _contaOrigem;
        private ContaCorrente _contaDestino;
        private Operacao _operacao;

        private ServicoContaCorrente _servicoContaCorrente;

        public UtilitarioDeOperacoes(Operacao operacao)
        {
            _servicoContaCorrente = new ServicoContaCorrente();
            _operacao = operacao;
            _contaDestino = _servicoContaCorrente.Consulte(_operacao.ContaDestino);
            _contaOrigem = _servicoContaCorrente.Consulte(_operacao.ContaOrigem);
        }

        public bool ApliqueOperacao()
        {
            switch(_operacao.Tipo)
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
            else
            {
                Console.Error.WriteLine("O valor para saque é maior do que o disponível em conta.");
                return false;
            }
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
            else
            {
                Console.Error.WriteLine("O valor para saque é maior do que o disponível em conta.");
                return false;
            }
        }
    }
}
