using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace csharp7.R02.depois
{
    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            int[] numeros = { 2, 7, 1, 9, 12, 8, 15 };
            ref int numero = ref LocalizarNumero(12, numeros);
            numero = -12;
            WriteLine(numeros[4]);
        }

        public ref int LocalizarNumero(int valor, int[] numeros)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] == valor)
                {
                    return ref numeros[i];
                }
            }

            throw new IndexOutOfRangeException("Não encontrado!");
        }
    }
}
