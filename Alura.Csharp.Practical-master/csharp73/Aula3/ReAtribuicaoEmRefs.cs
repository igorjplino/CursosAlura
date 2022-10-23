using System;
using System.Collections.Generic;
using System.Text;

namespace csharp73.Aula3
{
    class ReAtribuicaoEmRefs
    {
        public static void TestaRefs()
        {
            var numeros = new[] { 1, 3, 7, 15, 31, 1023, 63, 127, 255, 511 };
            EscrevaNumeros(numeros);

            ref var maiorNumero = ref ObterMaiorValor(numeros);

            Console.WriteLine($"Maior número: {maiorNumero}");

            maiorNumero *= 2;
            Console.WriteLine($"Maior número * 2: {maiorNumero}");

            EscrevaNumeros(numeros);
        }

        private static void EscrevaNumeros(int[] numeros)
        {
            Console.WriteLine(string.Join(", ", numeros));
        }

        public static ref int ObterMaiorValor(int[] numeros)
        {
            ref var maior = ref numeros[0];
            for (int i = 1; i < numeros.Length; i++)
            {
                if (numeros[i] > maior)
                {
                    // Essa operação não era permitida antes da versão 7.3
                    // Agora é possivel alterar a referência das variáveis de referência
                    maior = ref numeros[i];
                }
            }

            return ref maior;
        }

        public static ref int ObterMaiorValor2(int[] numeros)
        {
            // Span foi adicionado na versão 7.3, ele permite pegar a referência do item em um 'foreach'
            Span<int> numerosSpan = new Span<int>(numeros);

            ref var maior = ref numeros[0];

            foreach (ref var numero in numerosSpan.Slice(0))
            {
                if (numero > maior)
                {
                    maior = ref numero;
                }
            }

            return ref maior;
        }
    }
}
