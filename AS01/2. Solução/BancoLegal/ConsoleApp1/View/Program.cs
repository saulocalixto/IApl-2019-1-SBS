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

            Console.WriteLine("Seja muito bem vindo ao banco legal!");

            int escolha = -1;

            while (escolha != 0)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Enviar pessoa");
                Console.WriteLine("2 - Enviar conta");
                Console.WriteLine("3 - Consultar pessoa");
                Console.WriteLine("4 - Consultar conta");
                Console.WriteLine("0 - Sair");

                escolha = Int32.Parse(Console.ReadLine());
                int id;
                String caminho;

                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("Digite o caminho completo onde o arquivo de importação se encontra:");
                        caminho = Console.ReadLine();
                        servicoPessoa.CarregaArquivo(caminho);
                        break;
                    case 2:
                        Console.WriteLine("Digite o caminho completo onde o arquivo de importação se encontra:");
                        caminho = Console.ReadLine();
                        servicoConta.CarregaArquivo(caminho);
                        break;
                    case 3:
                        Console.WriteLine("Digite o id da pessoa consultada:");
                        id = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(servicoPessoa.Consulte(id));
                        break;
                    case 4:
                        Console.WriteLine("Digite o id da conta consultada:");
                        id = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(servicoConta.Consulte(id));
                        break;
                }
            }
        }
    }
}
