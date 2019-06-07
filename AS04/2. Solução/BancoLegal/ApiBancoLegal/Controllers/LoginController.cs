using Microsoft.AspNetCore.Mvc;

namespace ApiBancoLegal.Controllers
{
    public class LoginController : ControllerBase
    {
        public LoginController()
        {
        }

        [HttpGet]
        public ActionResult<string> Get(int idConta)
        {
            return ""; //ServicoLogin()....
        }
    }
}
