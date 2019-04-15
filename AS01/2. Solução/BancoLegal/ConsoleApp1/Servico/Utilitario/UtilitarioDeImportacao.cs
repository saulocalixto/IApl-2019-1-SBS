using BancoLegal.Model.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Setta de forma dinâmica os valores em cada propriedade do objeto a depender do arquivo passado.
        /// </summary>
        /// <typeparam name="TObjeto">Tipo do objeto para ser preenchido.</typeparam>
        /// <param name="objeto">Objeto a ser preenchido.</param>
        /// <param name="linhas">Linhas do arquivo de importação.</param>
        /// <returns></returns>
        public List<TObjeto> TransformeLinhaEmObjeto<TObjeto>(List<string> linhas)
        {
            List<TObjeto> objetos = new List<TObjeto>();
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

        /// <summary>
        /// Setta de forma dinâmica os valores em cada propriedade do objeto a depender do arquivo passado.
        /// </summary>
        /// <typeparam name="TObjeto">Tipo do objeto para ser preenchido.</typeparam>
        /// <param name="objeto">Objeto a ser preenchido.</param>
        /// <param name="linhas">Linhas do arquivo de importação.</param>
        /// <returns></returns>
        public string TransformeObjetoEmLinha<TObjeto>(TObjeto objeto)
        {
            StringBuilder linha = new StringBuilder();

            foreach (var propriedade in objeto.GetType().GetProperties().OrderBy(x => ((Importacao)x.GetCustomAttributes(true).FirstOrDefault()).Posicao))
            {
                var metaDado = ((Importacao)propriedade.GetCustomAttributes(true).FirstOrDefault());

                var valor = propriedade.GetValue(objeto);

                var valorConvertido = ConverteDado(metaDado.Tipo, metaDado.Tamanho, valor);

                linha.Append(valorConvertido);
            }

            return linha.ToString();
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
                case TiposEnum.Enumerador:
                    return int.Parse(dado);
                default:
                    return dado;
            }
        }

        public string ConverteDado(TiposEnum tipo, int tamanho, dynamic dado)
        {
            switch (tipo)
            {
                case TiposEnum.Booleano:
                    return dado ? "S" : "N";
                case TiposEnum.Texto:
                    return dado.PadRight(tamanho);
                case TiposEnum.Data:
                    return dado.ToString("dd/MM/yyyy");
                case TiposEnum.Decimal:
                    return dado.ToString().PadRight(tamanho);
                case TiposEnum.Numerico:
                    return dado.ToString().PadRight(tamanho);
                case TiposEnum.Enumerador:
                    return ((int)dado).ToString();
                default:
                    return dado;
            }
        }

    }
}
