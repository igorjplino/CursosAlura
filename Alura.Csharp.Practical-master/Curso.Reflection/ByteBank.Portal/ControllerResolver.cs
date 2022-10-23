using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Portal.Infraestrutura.IoC;

namespace ByteBank.Portal
{
    public class ControllerResolver
    {
        private readonly IContainer _container;

        public ControllerResolver(IContainer container)
        {
            _container = container;
        }

        public object ObterController(string nomeController)
        {
            var tipoController = Type.GetType(nomeController);
            var instanciaController = _container.Recuperar(tipoController);

            return instanciaController;
        }
    }
}
