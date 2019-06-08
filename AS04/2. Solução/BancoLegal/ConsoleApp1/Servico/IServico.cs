using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Servico
{
    public interface IServico<TObjeto>
    {
        /// <summary>
        /// Importa um arquivo de texto e salva-o no banco de dados.
        /// </summary>
        /// <param name="objeto">Objeto a ser cadastrado.</param>
        void Insert(TObjeto objeto);

        /// <summary>
        /// Consulta um conceito por id e o retorna para o usuário em formato de arquivo de texto.
        /// </summary>
        /// <param name="Id">Id do conceito pesquisado.</param>
        /// <returns>Retorna a string que representa o objeto pesquisado.</returns>
        TObjeto Consulte(int Id);

        /// <summary>
        /// Consulta uma lista de objetos.
        /// </summary>
        /// <returns>Retorna lista de objetos.</returns>
        List<TObjeto> Consulte();

        /// <summary>
        /// Atualiza um objeto.
        /// </summary>
        /// <param name="objeto">Objeto a ser atualizado.</param>
        void Atualize(TObjeto objeto);

        /// <summary>
        /// Verifica se objeto existe no banco.
        /// </summary>
        /// <param name="Id">Id do objeto a ser consultado.</param>
        /// <returns>Retorna indicador de sua existência.</returns>
        bool ObjetoExiste(int Id);

        /// <summary>
        /// Deletea um objeto.
        /// </summary>
        /// <param name="id">O id do objeto a ser deletado.</param>
        void Delet(int id);
    }
}
