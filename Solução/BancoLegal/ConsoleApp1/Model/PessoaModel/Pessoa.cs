using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Model.PessoaModel
{
    public class Pessoa
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Endereco { get; set; }
    }
}
