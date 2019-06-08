namespace ServicoBancoLegal.BancoDeDados.Interfaces
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

        /// <summary>
        /// Atualiza um conceito.
        /// </summary>
        /// <param name="objeto">Objeto a ser atualizado.</param>
        void Atualize(T objeto);

        /// <summary>
        /// Deleta um item no banco.
        /// </summary>
        /// <param name="id">Id do item a ser deletado.</param>
        void Delet(int id);

        /// <summary>
        /// Verifica se item está cadastrado.
        /// </summary>
        /// <param name="id">Id do item cadastrado.</param>
        /// <returns>Retorna se o item existe ou não.</returns>
        bool ExisteObjeto(int id);
    }
}
