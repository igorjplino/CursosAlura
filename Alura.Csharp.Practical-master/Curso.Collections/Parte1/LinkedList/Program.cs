using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ///
            /// LinkedList é uma lista de elementos (ou nós).
            /// Cada elemento pode apontar para outro elemento Antes ou Depois (Before ou After) dele.
            /// 
            /// É ideal utilizar LinkedList quando é necessário adicionar um elemento
            /// em uma posição específica, algo que demanda muito processo com List ou Array.

            //instanciando uma nova lista ligada: dias da semana
            LinkedList<string> dias = new LinkedList<string>();

            //adicionando valores
            var d4 = dias.AddFirst("quarta");
            var d2 = dias.AddBefore(d4, "segunda");
            var d3 = dias.AddAfter(d2, "terça");
            var d6 = dias.AddAfter(d4, "sexta");
            var d7 = dias.AddAfter(d6, "sábado");
            var d5 = dias.AddBefore(d6, "quinta");
            var d1 = dias.AddBefore(d2, "domingo");

            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }

            ///
            /// LinkedList não dá suporte ao acesso por meio de índices. 
            /// No caso de querermos usar dias[0], por exemplo, teremos uma sintaxe inválida.

            ///
            /// LinkedList facilita muito o acesso à inserção e remoção rápidas, porém, 
            /// ele não é tão eficiente na realização de buscas. Para isto, utilizaremos o método Find()
            var quarta = dias.Find("quarta");

            Console.WriteLine();

            dias.Remove("quarta"); // ou dias.Remove(d4)
            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }

            Console.ReadLine();
        }
    }
}
