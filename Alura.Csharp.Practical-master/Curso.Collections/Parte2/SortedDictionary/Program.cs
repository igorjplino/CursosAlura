using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, Aluno> sorted = new SortedDictionary<string, Aluno>();

            sorted.Add("VT", new Aluno("Vanessa", 34672));
            sorted.Add("AL", new Aluno("Ana", 5617));
            sorted.Add("RN", new Aluno("Rafael", 17645));
            sorted.Add("WM", new Aluno("Wanderson", 11287));

            ///
            /// O SortedDictionary imprime os valores ordenados pela chave.
            /// 
            /// SortedList, que trabalha com um IList, ao removermos um elemento, ela precisa se reajustar, 
            /// para poder ocupar o vazio deixado. Da mesma forma, ao adicionarmos um elemento, 
            /// ela aumentará de tamanho e realocará seus itens. 
            /// Por isso, uma inserção ou remoção muito frequente de elementos, neste tipo de lista, 
            /// é menos eficiente do que num SortedDictionary.
            /// 
            /// Entretanto, caso o objetivo seja criar uma coleção em que todos os elementos iniciais já estão definidos, 
            /// o mais indicado seria a SortedList.
            /// 
            /// Em caso de dúvida, recomenda-se iniciar com um SortedDictionary.

            Console.WriteLine();
            foreach (var aluno in sorted)
            {
                Console.WriteLine(aluno);
            }

            Console.Read();
        }
    }
}
