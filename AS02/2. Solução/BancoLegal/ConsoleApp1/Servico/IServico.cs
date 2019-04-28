using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Servico
{
    public interface IServico<TObjeto>
    {
        void ImporteArquivo(string caminhoArquivo);
        string Consulte(int Id);
        string Consulte();
        void Atualize(TObjeto objeto);
    }
}
