using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp7.R12.antes
{
    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            var caracteres = Alfabeto.SubconjuntoDoAlfabeto('c', 'o');

            foreach (var caracter in caracteres)
            {
                Console.WriteLine(caracter);
            }
        }
    }

    class Alfabeto
    {
        public static IEnumerable<char> SubconjuntoDoAlfabeto(char inicio, char fim)
        {
            if (inicio < 'a' || inicio > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(inicio), message: "início deve ser uma letra");
            if (fim < 'a' || fim > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(fim), message: "final deve ser uma letra");

            if (fim <= inicio)
                throw new ArgumentException($"{nameof(fim)} deve ser maior que {nameof(inicio)}");

            return ImplementacaoSubconjuntoDoAlfabeto(inicio, fim);
        }

        private static IEnumerable<char> ImplementacaoSubconjuntoDoAlfabeto(char inicio, char fim)
        {
            for (var c = inicio; c < fim; c++)
                yield return c;
        }
    }

    class Tarefas
    {
        public Task<string> ExecutarTrabalhoDemorado(string endereco, int indice, string nome)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException(message: "Endereço obrigatório", paramName: nameof(endereco));
            if (indice < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(indice), message: "Índice não pode ser negativo");
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException(message: "Nome obrigatório", paramName: nameof(nome));

            return ImplementacaoTrabalhoDemorado(endereco, indice, nome);
        }

        private static async Task<string> ImplementacaoTrabalhoDemorado(string endereco, int indice, string nome)
        {
            var primeiroResultado = await PrimeiroPasso(endereco);
            var segundoResultado = await SegundoPasso(indice, nome);
            return $"Os resultados são {primeiroResultado} e {segundoResultado}.";
        }

        private static Task<int> SegundoPasso(int index, string name)
        {
            throw new NotImplementedException();
        }

        private static Task<int> PrimeiroPasso(string address)
        {
            throw new NotImplementedException();
        }
    }

}
