using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Servico
{
    public class ServicoBasico<T> : IServico<T>
    {
        public string Consulte(int Id)
        {
            throw new NotImplementedException();
        }

        public void ImporteArquivo(string caminhoArquivo)
        {
            throw new NotImplementedException();
        }
    }
}
