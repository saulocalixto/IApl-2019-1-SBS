using BancoLegal.Model.DataAnnotations;
using System;
using System.Collections.Generic;

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

        public dynamic ConverteDado(TiposEnum tipo, string dado)
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
                    return decimal.Parse(dado);
                case TiposEnum.Numerico:
                    return int.Parse(dado);
                default:
                    return dado;

            }
        }

    }
}
