using System;
using ServicoBancoLegal.Resources;

namespace ServicoBancoLegal.Servico.Fabrica
{
    public class FabricaGenerica<T>
    {
        private FabricaGenerica() { }

        public static T Crie()
        {
            var tipo = typeof(T);

            if (tipo.IsAbstract || tipo.IsInterface)
            {
                throw new ArgumentException(Strings.CantInstantiateAbstractClass);
            }

            return Activator.CreateInstance<T>(); ;
        }
    }
}
