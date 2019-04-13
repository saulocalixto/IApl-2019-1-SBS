using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.BancoDeDados.Interfaces
{
    public interface IRepositorio<T>
    {
        /// <summary>
        /// Consulte um conceito pelo id.
        /// </summary>
        /// <param name="id">Id do conceito consultado.</param>
        /// <returns>Retorna o objeto relacionado àquele conceito.</returns>
        T Consulte(int id);

        /// <summary>
        /// Cadastre um conceito.
        /// </summary>
        /// <param name="objeto">Objeto a ser cadastrado.</param>
        void Cadastre(T objeto);
    }
}
