using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, Aluno> alunos = new Dictionary<string, Aluno>();

            alunos.Add("VT", new Aluno("Vanessa", 34672));
            alunos.Add("AL", new Aluno("Ana", 5617));
            alunos.Add("RN", new Aluno("Rafael", 17645));
            alunos.Add("WM", new Aluno("Wanderson", 11287));

            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            //vamos remover: AL
            alunos.Remove("AL");
            //vamos.adicionar: MO
            alunos.Add("MO", new Aluno("Marcelo", 12345));

            ///
            /// O aluno Marcelo foi adicionado na mesma posição
            /// do aluno removido e não no final. Caracteristicamente, 
            /// não é possível sabermos com precisão a localização dos itens no momento da impressão.
            /// 
            /// O Dictionary, internamente, utiliza um hash para armazenar as chaves.

            Console.WriteLine();
            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            //apresentando nova coleção...SortedList

            IDictionary<string, Aluno> sorted = new SortedList<string, Aluno>();

            sorted.Add("VT", new Aluno("Vanessa", 34672));
            sorted.Add("AL", new Aluno("Ana", 5617));
            sorted.Add("RN", new Aluno("Rafael", 17645));
            sorted.Add("WM", new Aluno("Wanderson", 11287));

            ///
            /// O SortedList imprime os valores ordenados pela chave.
            /// Temos uma estrutura diferente de armazenamento de chaves e valores. 
            /// Não teremos a coleção que utiliza o "hash", em vez disso, haverá uma lista automaticamente ordenada. 
            /// Ou seja, cada vez que inserimos um valor, ele será ordenado automaticamente.

            Console.WriteLine();
            foreach (var aluno in sorted)
            {
                Console.WriteLine(aluno);
            }

            Console.Read();
        }
    }
}
