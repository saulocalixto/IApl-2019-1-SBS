using ServicoBancoLegal.Model.ContaModel;
using ServicoBancoLegal.Servico;

namespace ApiBancoLegal.Controllers
{
    public class ContaController : ControllerPadrao<ContaCorrente>
    {
        public override ServicoPadrao<ContaCorrente> Servico()
        {
            return new ServicoContaCorrente();
        }
    }
}