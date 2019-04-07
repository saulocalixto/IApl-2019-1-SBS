﻿using BancoLegal.Model.DataAnnotations;
using BancoLegal.Model.PessoaModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Model.ContaModel
{
    public abstract class ContaPadrao : ObjetoPadrao
    {
        [Importacao(NomeCampo = "Titular", Tamanho = 5, Posicao = 2, Tipo = TiposEnum.Numerico)]
        public int Titular { get; set; }

        [Importacao(NomeCampo = "Agência", Tamanho=5, Posicao = 3, Tipo = TiposEnum.Numerico)]
        public int Agencia { get; set; }

        [Importacao(NomeCampo = "Número", Tamanho = 10, Posicao = 4, Tipo = TiposEnum.Numerico)]
        public int Numero { get; set; }

        [Importacao(NomeCampo = "Senha", Tamanho = 40, Posicao = 5, Tipo = TiposEnum.Numerico)]
        public int Senha { get; set; }

        [Importacao(NomeCampo = "Saldo", Tamanho = 20, Posicao = 6, Tipo = TiposEnum.Decimal)]
        public double Saldo { get; set; }

        [Importacao(NomeCampo = "Limite", Tamanho = 20, Posicao = 7, Tipo = TiposEnum.Decimal)]
        public double Limite { get; set; }

        [Importacao(NomeCampo = "Ativo", Tamanho = 1, Posicao = 8, Tipo = TiposEnum.Booleano)]
        public bool Ativo { get; set; }
    }
}
