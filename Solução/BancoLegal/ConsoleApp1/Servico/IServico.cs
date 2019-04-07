using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Servico
{
    public interface IServico<TObjeto>
    {
        void CarregaArquivo(string caminhoArquivo);
        string Consulte(int Id);
        string EmiteLayout();
    }
}
