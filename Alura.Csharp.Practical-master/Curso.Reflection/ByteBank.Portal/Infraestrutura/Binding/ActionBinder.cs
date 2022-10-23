using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura.Binding
{
    public class ActionBinder
    {
        public ActionBindInfo ObterMethodInfo(object controller, string path)
        {
            // Tipos de queries esperadas
            // /Cambio/Calculo?moedaOrigem=BRL&moedaDestino=USD&valor=10
            // /Cambio/Calculo?moedaDestino=USD&valor=10
            // /Cambio/USD

            var idxInterrogacao = path.IndexOf('?');

            if (idxInterrogacao < 0)
            {
                var nomeAction = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1];
                return new ActionBindInfo(controller.GetType().GetMethod(nomeAction), Enumerable.Empty<ArgumentoNomeValor>());
            }
            else
            {
                var nomeControllerComAction = path.Substring(0, idxInterrogacao);
                var queryString = path.Substring(idxInterrogacao + 1);
                var nomeAction = nomeControllerComAction.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1];

                var tuplasNomeValor = ObterArgumentosNomeValores(queryString);
                var nomeArgumentos = tuplasNomeValor.Select(tupla => tupla.Nome).ToArray();

                var methodInfo = ObterMethodInfoAPartirDeNomeEArgumentos(nomeAction, nomeArgumentos, controller);

                return new ActionBindInfo(methodInfo, tuplasNomeValor);
            }
        }

        private IEnumerable<ArgumentoNomeValor> ObterArgumentosNomeValores(string queryString)
        {
            var tuplasNomeValor = queryString.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var tupla in tuplasNomeValor)
            {
                var partesTupla = tupla.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                yield return new ArgumentoNomeValor(partesTupla[0], partesTupla[1]);
            }
        }

        private MethodInfo ObterMethodInfoAPartirDeNomeEArgumentos(string nomeAction, string[] argumentos, object controller)
        {
            var bindingFlags =
                BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.Public
                | BindingFlags.DeclaredOnly;

            var metodos = controller.GetType().GetMethods(bindingFlags);
            var sobrecargas = metodos.Where(metodo => metodo.Name == nomeAction);

            foreach (var sobrecarga in sobrecargas)
            {
                var parametros = sobrecarga.GetParameters();

                if (argumentos.Length != parametros.Length)
                    continue;

                if (parametros.All(parametro => argumentos.Contains(parametro.Name)))
                {
                    return sobrecarga;
                }
            }

            throw new ArgumentException($"A sobrecarga do método {nomeAction} não foi encontrada!");
        }
    }
}
