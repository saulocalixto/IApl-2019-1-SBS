﻿using System;
using ServicoBancoLegal.Model.DataAnnotations;

namespace ServicoBancoLegal.Model.PessoaModel
{
    public class Pessoa : ObjetoPadrao
    {
        [Importacao(NomeCampo = "Nome Titular", Tamanho = 100, Posicao = 2, Tipo = TiposEnum.Texto)]
        public string Nome { get; set; }

        [Importacao(NomeCampo = "Cpf", Tamanho = 11, Posicao = 3, Tipo = TiposEnum.Texto)]
        public string Cpf { get; set; }

        [Importacao(NomeCampo = "Data de Nascimento", Tamanho = 10, Posicao = 4, Tipo = TiposEnum.Data)]
        public DateTime DataNascimento { get; set; }

        [Importacao(NomeCampo = "Endereco", Tamanho = 100, Posicao = 5, Tipo = TiposEnum.Texto)]
        public string Endereco { get; set; }

        [Importacao(NomeCampo = "Email", Tamanho = 100, Posicao = 6, Tipo = TiposEnum.Texto)]
        public string Email { get; set; }
    }
}
