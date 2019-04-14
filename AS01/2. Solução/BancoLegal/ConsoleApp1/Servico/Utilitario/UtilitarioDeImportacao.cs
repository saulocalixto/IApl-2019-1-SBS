using BancoLegal.Model.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Setta de forma dinâmica os valores em cada propriedade do objeto a depender do arquivo passado.
        /// </summary>
        /// <typeparam name="TObjeto">Tipo do objeto para ser preenchido.</typeparam>
        /// <param name="objeto">Objeto a ser preenchido.</param>
        /// <param name="linhas">Linhas do arquivo de importação.</param>
        /// <returns></returns>
        public List<TObjeto> settaValor<TObjeto>(List<string> linhas)
        {
            List<TObjeto> objetos = new List<TObjeto>();
            var tipo = typeof(TObjeto);
            IList<Importacao> listaImportacao = RetorneMetaDados<TObjeto>();
            TObjeto objeto = Activator.CreateInstance<TObjeto>();
            
            foreach (var linha in linhas)
            {
                var posicaoInicial = 0;
                foreach (var propriedade in objeto.GetType().GetProperties().OrderBy(x => ((Importacao)x.GetCustomAttributes(true).FirstOrDefault()).Posicao))
                {
                    var metaDado = ((Importacao)propriedade.GetCustomAttributes(true).FirstOrDefault());
                    objeto
                    .GetType()
                    .GetProperties()
                    .FirstOrDefault(x => x.Equals(propriedade))
                    .SetValue(objeto, ConverteDado(metaDado.Tipo, linha.Substring(posicaoInicial, metaDado.Tamanho).Trim()));
                    posicaoInicial += metaDado.Tamanho;
                }

                objetos.Add(objeto);
            }

            return objetos;
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
