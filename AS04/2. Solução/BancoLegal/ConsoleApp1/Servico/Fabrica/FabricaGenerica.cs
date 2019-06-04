using BancoLegal.Localization;
using System;

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
                throw new ArgumentException(Strings.CantInstantiateAbstractClass);
            }

            return Activator.CreateInstance<T>(); ;
        }
    }
}
