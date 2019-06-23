namespace ServicoBancoLegal.BancoDeDados.Interfaces
{
    public interface IRepositorio<T>
    {
        /// <summary>
        /// Consulte um conceito pelo id.
        /// </summary>
        /// <param name="id">Id do conceito consultado.</param>
        /// <returns>Retorna o objeto relacionado àquele conceito.</returns>
        T Get(int id);

        /// <summary>
        /// Cadastre um conceito.
        /// </summary>
        /// <param name="objeto">Objeto a ser cadastrado.</param>
        void Insert(T objeto);

        /// <summary>
        /// Atualiza um conceito.
        /// </summary>
        /// <param name="objeto">Objeto a ser atualizado.</param>
        void Update(T objeto);

        /// <summary>
        /// Deleta um item no banco.
        /// </summary>
        /// <param name="id">Id do item a ser deletado.</param>
        void Delete(int id);

        /// <summary>
        /// Verifica se item está cadastrado.
        /// </summary>
        /// <param name="id">Id do item cadastrado.</param>
        /// <returns>Retorna se o item existe ou não.</returns>
        bool ObjectExists(int id);
    }
}
