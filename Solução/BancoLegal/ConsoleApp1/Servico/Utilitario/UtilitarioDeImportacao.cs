using BancoLegal.Model;
using BancoLegal.Model.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Servico.Utilitario
{
    public class UtilitarioDeImportacao
    {
        public IList<Importacao> RetorneMetaDados<TObjeto>()
        {
            var tipo = typeof(TObjeto);
            List<Importacao> listaImportacao = new List<Importacao>();

            foreach (var propriedade in tipo.GetProperties())
            {
                var customAtributo = propriedade.GetCustomAttributes(true)[0] as Importacao;
                listaImportacao.Add(customAtributo);
            }

            return listaImportacao;
        }

        public dynamic converteDado(TiposEnum tipo, string dado)
        {
            switch (tipo)
            {
                case TiposEnum.Booleano:
                    return dado == "S" ? true : false;
                case TiposEnum.Texto:
                    return dado;
                case TiposEnum.Data:
                    return DateTime.Parse(dado);
                case TiposEnum.Decimal:
                    return Double.Parse(dado);
                case TiposEnum.Numerico:
                    return Int64.Parse(dado);
                default:
                    return dado;

            }
        }

    }
}
