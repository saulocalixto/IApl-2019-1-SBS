using BancoLegal.Model.OperacaoModel;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace BancoLegal.BancoDeDados.Repositorio
{
    class RepositorioOperacao : RepositorioPadrao<Operacao>
    {
        protected override Operacao Consulte(DbDataReader reader)
        {
            Operacao operacao = new Operacao();
            while (reader.Read())
            {
                operacao.Id = reader.GetInt32(0);
                operacao.Tipo = (EnumTipoOperacao)reader.GetInt32(1);
                operacao.Valor = reader.GetDecimal(2);
                operacao.DataDaOperacao = reader.GetDateTime(3);
                operacao.ContaOrigem = reader.GetInt32(4);
                operacao.ContaDestino = reader.GetInt32(5);
            }
            return operacao;
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

        protected override string StringDeInsert()
        {
            return "Insert into OPERACAO(ID, TIPO, VALOR, DATA, ORIGEM, DESTINO) Values(@id, @tipo, @valor, @data, @origem, @destino);";
        }

        protected override string StringDeSelect()
        {
            return "SELECT * FROM OPERACAO WHERE id = @id";
        }
    }
}
