using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Servico
{
    public interface IServico<TObjeto>
    {
        void ImporteArquivo(string caminhoArquivo);
        TObjeto Consulte(int Id);
        List<TObjeto> Consulte();
        void Atualize(TObjeto objeto);
    }
}
