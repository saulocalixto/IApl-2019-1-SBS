using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using MySql.Data.MySqlClient;
using ServicoBancoLegal.Model.OperacaoModel;

namespace ServicoBancoLegal.BancoDeDados.Repositorio
{
    class RepositorioOperacao : RepositorioPadrao<Operacao>
    {
        protected override List<Operacao> Consulte(DbDataReader reader)
        {
            var lista = new List<Operacao>();
            while (reader.Read())
            {
                var operacao = new Operacao
                {
                    Id = reader.GetInt32(0),
                    Tipo = (EnumTipoOperacao) reader.GetInt32(1),
                    Valor = reader.GetDecimal(2),
                    DataDaOperacao = reader.GetDateTime(3),
                    ContaOrigem = reader.GetInt32(4),
                    ContaDestino = reader.GetInt32(5)
                };

                lista.Add(operacao);
            }
            return lista;
        }

        protected override void MapeieCampos(Operacao objeto, MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id", objeto.Id);
            cmd.Parameters.AddWithValue("@tipo", objeto.Tipo);
            cmd.Parameters.AddWithValue("@valor", objeto.Valor);
            cmd.Parameters.AddWithValue("@data", objeto.DataDaOperacao);
            cmd.Parameters.AddWithValue("@origem", objeto.ContaOrigem);
            cmd.Parameters.AddWithValue("@destino", objeto.ContaDestino);
        }

        protected override string NomeTabela()
        {
            return "OPERACAO";
        }

        protected override string StringDeInsert()
        {
            return "Insert into OPERACAO(ID, TIPO, VALOR, DATA, ORIGEM, DESTINO) Values(@id, @tipo, @valor, @data, @origem, @destino);";
        }

        protected override string StringDeUpdate()
        {
            var query = new StringBuilder();

            query.Append("UPDATE OPERACAO ")
                .AppendLine("SET Nome = @nome,")
                .AppendLine("DATA = @data")
                .AppendLine("WHERE ID = @id");

            return query.ToString();
        }
    }
}
