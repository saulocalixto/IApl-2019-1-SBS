using BancoLegal.Servico;
using System;

namespace BancoLegal.View
{
    public class Program
    {
        static void Main(string[] args)
        {
            var servicoPessoa = new ServicoPessoa();
            var servicoConta = new ServicoContaCorrente();
            var servicoOperacao = new ServicoOperacaoTransferencia();

            Console.WriteLine("Seja muito bem vindo ao banco legal!");

            int escolha = -1;

            while (escolha != 0)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Enviar pessoa");
                Console.WriteLine("2 - Enviar conta");
                Console.WriteLine("3 - Enviar operação");
                Console.WriteLine("4 - Consultar pessoa");
                Console.WriteLine("5 - Consultar conta");
                Console.WriteLine("6 - Consultar operação");
                Console.WriteLine("0 - Sair");

                escolha = Int32.Parse(Console.ReadLine());
                var id = 0;
                string caminho;

                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("Digite o caminho completo onde o arquivo de importação se encontra:");
                        caminho = Console.ReadLine();
                        servicoPessoa.ImporteArquivo(caminho);
                        break;
                    case 2:
                        Console.WriteLine("Digite o caminho completo onde o arquivo de importação se encontra:");
                        caminho = Console.ReadLine();
                        servicoConta.ImporteArquivo(caminho);
                        break;
                    case 3:
                        Console.WriteLine("Digite o caminho completo onde o arquivo de importação se encontra:");
                        caminho = Console.ReadLine();
                        servicoOperacao.ImporteArquivo(caminho);
                        break;
                    case 4:
                        Console.WriteLine("Digite o id da pessoa consultada:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine(servicoPessoa.Consulte(id));
                        break;
                    case 5:
                        Console.WriteLine("Digite o id da conta consultada:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine(servicoConta.Consulte(id));
                        break;
                    case 6:
                        Console.WriteLine("Digite o id da operação consultada:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine(servicoOperacao.Consulte(id));
                        break;
                }
            }
        }
    }
}
