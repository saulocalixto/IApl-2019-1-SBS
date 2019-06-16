using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ServicoBancoLegal.Resources;

namespace ServicoBancoLegal.Servico.Utilitario
{
    public class UtilitarioLeitorDeArquivo
    {
        private string _caminhoArquivo;
        private Stream _entrada;
        private StreamReader _leitor;
        private List<string> _linhas;

        public UtilitarioLeitorDeArquivo(string caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo;
            _linhas = new List<string>();

            try
            {
                _entrada = File.Open(caminhoArquivo, FileMode.Open);
                _leitor = new StreamReader(_entrada, Encoding.UTF8);
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine(Strings.FileNotFound);
            }

        }

        public List<string> RetorneLinhas()
        {
            if (_leitor != null)
            {
                var linha = _leitor.ReadLine();

                while (linha != null)
                {
                    _linhas.Add(linha);
                    linha = _leitor.ReadLine();
                }

                FecharConexao();
            }

            return _linhas;
        }

        private void FecharConexao()
        {
            _leitor.Close();
            _entrada.Close();
        }
    }
}
