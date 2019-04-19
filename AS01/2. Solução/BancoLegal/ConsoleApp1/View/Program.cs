using BancoLegal.Servico;
using System;

namespace BancoLegal.View
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var menuLogin = new ViewLogin();
            menuLogin.Menu();
        }
    }
}
