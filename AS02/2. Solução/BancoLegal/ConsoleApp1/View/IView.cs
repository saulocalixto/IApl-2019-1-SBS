using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.View
{
    public interface IView
    {
        void Menu();
        void AcoesMenu(int acao);
    }
}
