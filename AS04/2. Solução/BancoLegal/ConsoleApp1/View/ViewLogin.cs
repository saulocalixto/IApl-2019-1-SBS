using BancoLegal.Servico;
using System;

namespace BancoLegal.View
{
    public class ViewLogin : IView
    {
        private int _escolha;
        private ServicoLogin _servicoLogin;
        private string _caminho;

        private MenuPadrao _menuPadrao;

        public void AcoesMenu(int acao)
        {
            switch(_escolha)
            {
                case 1:
                    if(EfetueLogin())
                    {
                        _menuPadrao = new MenuPadrao();
                        _menuPadrao.Menu();
                    } else
                    {
                        Console.WriteLine("Falha ao efetuar o login, verifique o arquivo importado.");
                    }

                    break;
            }
        }

        public void Menu()
        {
            Console.WriteLine("Seja muito bem vindo ao banco legal!");

            Console.WriteLine("O que deseja fazer?");
            _escolha = -1;
            while(_escolha != 0)
            {
                Console.WriteLine("1 - Login");
                Console.WriteLine("0 - Sair");

                _escolha = Int32.Parse(Console.ReadLine());

                AcoesMenu(_escolha);
                Console.Clear();
            }
        }

        private ServicoLogin ServicoLogin()
        {
            return _servicoLogin ?? (_servicoLogin = new ServicoLogin());
        }

        private bool EfetueLogin()
        {
            Console.WriteLine("Informe o caminho com a conta para Login: ");
            _caminho = Console.ReadLine();
            return ServicoLogin().EfetueLogin(_caminho);
        }
    }
}
