using BancoLegal.Model.ContaModel;
using BancoLegal.Servico;
using BancoLegal.Servico.Utilitario;
using System;
using System.Collections.Generic;

namespace BancoLegal.View
{
    public class Program
    {
        static void Main(string[] args)
        {
            var servicoPessoa = new ServicoPessoa();

            Console.WriteLine("Seja muito bem vindo ao banco legal!");

            int escolha = -1;

            while (escolha != 0)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Enviar pessoa");
                Console.WriteLine("2 - Enviar conta");
                Console.WriteLine("3 - Consultar pessoa");
                Console.WriteLine("4 - Consultar conta");
                Console.WriteLine("0 - Sair");

                escolha = Int32.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("Digite o caminho completo onde o arquivo de importação se encontra:");
                        var caminho = Console.ReadLine();

                        servicoPessoa.CarregaArquivo(caminho);
                        break;
                    case 2:
                        break;
                    case 3:
                        Console.WriteLine("Digite o id da pessoa consultada:");
                        var id = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(servicoPessoa.Consulte(id));
                        break;
                    case 4:
                        break;
                }
            }
        }
    }
}
