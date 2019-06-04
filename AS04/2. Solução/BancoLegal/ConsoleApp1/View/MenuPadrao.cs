using BancoLegal.Servico;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.View
{
    public class MenuPadrao : IView
    {
        private int _escolha;
        private string _caminho;
        private int _id;

        private ServicoPessoa _servicoPessoa;
        private ServicoContaCorrente _servicoConta;
        private ServicoOperacaoTransferencia _servicoOperacao;

        public void AcoesMenu(int acao)
        {
            switch (_escolha)
            {
                case 1:
                    Console.WriteLine("Digite o caminho completo onde o arquivo de importação se encontra:");
                    _caminho = Console.ReadLine();
                    ServicoPessoa().ImporteArquivo(_caminho);
                    break;
                case 2:
                    Console.WriteLine("Digite o caminho completo onde o arquivo de importação se encontra:");
                    _caminho = Console.ReadLine();
                    ServicoConta().ImporteArquivo(_caminho);
                    break;
                case 3:
                    Console.WriteLine("Digite o caminho completo onde o arquivo de importação se encontra:");
                    _caminho = Console.ReadLine();
                    ServicoOperacao().ImporteArquivo(_caminho);
                    break;
                case 4:
                    Console.WriteLine("Digite o id da pessoa consultada:");
                    _id = int.Parse(Console.ReadLine());
                    Console.WriteLine(ServicoPessoa().Consulte(_id));
                    Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Digite o id da conta consultada:");
                    _id = int.Parse(Console.ReadLine());
                    Console.WriteLine(ServicoConta().Consulte(_id));
                    Console.ReadLine();
                    break;
                case 6:
                    Console.WriteLine("Digite o id da operação consultada:");
                    _id = int.Parse(Console.ReadLine());
                    Console.WriteLine(ServicoOperacao().Consulte(_id));
                    Console.ReadLine();
                    break;
                case 7:
                    Console.WriteLine(ServicoPessoa().Consulte());
                    Console.ReadLine();
                    break;
                case 8:
                    Console.WriteLine(ServicoConta().Consulte());
                    Console.ReadLine();
                    break;
                case 9:
                    Console.WriteLine(ServicoOperacao());
                    Console.ReadLine();
                    break;
            }
        }

        public void Menu()
        {
            _escolha = -1;
            while (_escolha != 0)
            {
                Console.Clear();
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Enviar pessoa");
                Console.WriteLine("2 - Enviar conta");
                Console.WriteLine("3 - Enviar operação");
                Console.WriteLine("4 - Consultar pessoa");
                Console.WriteLine("5 - Consultar conta");
                Console.WriteLine("6 - Consultar operação");
                Console.WriteLine("7 - Consultar todas pessoas");
                Console.WriteLine("8 - Consultar todas contas");
                Console.WriteLine("9 - Consultar todas operações");
                Console.WriteLine("0 - Sair");

                _escolha = Int32.Parse(Console.ReadLine());

                AcoesMenu(_escolha);
            }
        }

        private ServicoPessoa ServicoPessoa()
        {
            return _servicoPessoa ?? (_servicoPessoa = new ServicoPessoa());
        }

        private ServicoContaCorrente ServicoConta()
        {
            return _servicoConta ?? (_servicoConta = new ServicoContaCorrente());
        }

        private ServicoOperacaoTransferencia ServicoOperacao()
        {
            return _servicoOperacao ?? (_servicoOperacao = new ServicoOperacaoTransferencia());
        }
    }
}
