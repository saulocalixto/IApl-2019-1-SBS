using ServicoBancoLegal.Model.OperacaoModel;
using ServicoBancoLegal.Servico;

namespace ApiBancoLegal.Controllers
{
    public class OperacaoController : ControllerPadrao<Operacao>
    {
        public override ServicoPadrao<Operacao> Service()
        {
            return new ServicoOperacaoTransferencia();
        }

        protected override void ExecuteServiceInsert(Operacao obj)
        {
            ((ServicoOperacaoTransferencia)Service()).ApliqueOperacao(obj);
            base.ExecuteServiceInsert(obj);
        }
    }
}