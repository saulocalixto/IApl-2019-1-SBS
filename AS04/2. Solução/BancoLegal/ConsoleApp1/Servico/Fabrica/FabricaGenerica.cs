using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Servico.Fabrica
{
    public class FabricaGenerica<T>
    {
        private FabricaGenerica() { }

        public static T Crie()
        {
            var tipo = typeof(T);

            if (tipo.IsAbstract || tipo.IsInterface)
            {
                throw new ArgumentException("Não é possível instanciar uma classe abstrata.");
            }

            return Activator.CreateInstance<T>(); ;
        }
    }
}
