﻿using BancoLegal.Model.ContaModel;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace BancoLegal.BancoDeDados.Repositorio
{
    public class RepositorioContaCorrente : RepositorioPadrao<ContaCorrente>
    {
        protected override void MapeieCampos(ContaCorrente conta, MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id", conta.Id);
            cmd.Parameters.AddWithValue("@numero", conta.Numero);
            cmd.Parameters.AddWithValue("@agencia", conta.Agencia);
            cmd.Parameters.AddWithValue("@titular", conta.Titular);
            cmd.Parameters.AddWithValue("@senha", conta.Senha);
            cmd.Parameters.AddWithValue("@saldo", conta.Saldo);
            cmd.Parameters.AddWithValue("@limite", conta.Limite);
            cmd.Parameters.AddWithValue("@status", conta.Ativo);
        }

        protected override List<ContaCorrente> Consulte(DbDataReader reader)
        {
            var listaContaCorrente = new List<ContaCorrente>();
            while (reader.Read())
            {
                var conta = new ContaCorrente
                {
                    Id = reader.GetInt32(0),
                    Numero = reader.GetInt32(1),
                    Agencia = reader.GetInt32(2),
                    Titular = reader.GetInt32(3),
                    Senha = reader.GetString(4),
                    Saldo = reader.GetDecimal(5),
                    Limite = reader.GetDecimal(6),
                    Ativo = reader.GetBoolean(7)
                };

                listaContaCorrente.Add(conta);
            }
            return listaContaCorrente;
        }

        protected override string StringDeInsert()
        {
            return "Insert into CONTA (ID, NUMERO, AGENCIA, TITULAR, SENHA," +
                " SALDO, LIMITE, STATUS, TIPO) Values (@id, @numero, @agencia, @titular, @senha, @saldo, @limite, @status, 1);";
        }

        protected override string StringDeUpdate()
        {
            var query = new StringBuilder();

            query.Append("UPDATE CONTA ")
                .AppendLine("SET SALDO = @saldo,")
                .AppendLine("LIMITE = @limite")
                .AppendLine("WHERE ID = @id");

            return query.ToString();
        }

        protected override string NomeTabela()
        {
            return "CONTA";
        }
    }
}
