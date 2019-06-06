using BancoLegal.Resources;
using BancoLegal.Servico;
using System;

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
                    Console.WriteLine(Strings.ProvideFullPathToImportFile);
                    _caminho = Console.ReadLine();
                    ServicoPessoa().ImporteArquivo(_caminho);
                    break;
                case 2:
                    Console.WriteLine(Strings.ProvideFullPathToImportFile);
                    _caminho = Console.ReadLine();
                    ServicoConta().ImporteArquivo(_caminho);
                    break;
                case 3:
                    Console.WriteLine(Strings.ProvideFullPathToImportFile);
                    _caminho = Console.ReadLine();
                    ServicoOperacao().ImporteArquivo(_caminho);
                    break;
                case 4:
                    Console.WriteLine(Strings.InsertPersonId);
                    _id = int.Parse(Console.ReadLine());
                    Console.WriteLine(ServicoPessoa().Consulte(_id));
                    Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine(Strings.InsertPersonId);
                    _id = int.Parse(Console.ReadLine());
                    Console.WriteLine(ServicoConta().Consulte(_id));
                    Console.ReadLine();
                    break;
                case 6:
                    Console.WriteLine(Strings.InsertPersonId);
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
                Console.WriteLine("\n" + Strings.ChooseOption);
                Console.WriteLine("1 - " + Strings.OptionSetPerson);
                Console.WriteLine("2 - " + Strings.OptionSetAccount);
                Console.WriteLine("3 - " + Strings.OptionSetOperation);
                Console.WriteLine("4 - " + Strings.OptionGetPerson);
                Console.WriteLine("5 - " + Strings.OptionGetAccount);
                Console.WriteLine("6 - " + Strings.OptionGetOperation);
                Console.WriteLine("7 - " + Strings.OptionGetAllPersons);
                Console.WriteLine("8 - " + Strings.OptionGetAllAccounts);
                Console.WriteLine("9 - " + Strings.OptionGetAllOperations);
                Console.WriteLine("0 - " + Strings.OptionExit);

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
