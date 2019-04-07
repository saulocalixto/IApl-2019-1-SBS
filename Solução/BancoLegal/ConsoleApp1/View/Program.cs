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
            servicoPessoa.CarregaArquivo("");
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
