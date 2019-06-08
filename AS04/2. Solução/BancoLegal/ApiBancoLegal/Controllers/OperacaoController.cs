using ServicoBancoLegal.Model.OperacaoModel;
using ServicoBancoLegal.Servico;

namespace ApiBancoLegal.Controllers
{
    public class OperacaoController : ControllerPadrao<Operacao>
    {
        public override ServicoPadrao<Operacao> Servico()
        {
            return new ServicoOperacaoTransferencia();
        }
    }
}