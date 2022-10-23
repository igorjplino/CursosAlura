using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaSomenteLeitura
{
    class Program
    {
        static void Main(string[] args)
        {
            var csharpColecoes = new Curso("C# Colecoes", "Marcelo Oliveira");

            var a1 = new Aluno("Vanessa Tonini", 34672);
            var a2 = new Aluno("Ana Losnak", 5617);
            var a3 = new Aluno("Rafael Nercessian", 17645);

            csharpColecoes.Matricular(a1);
            csharpColecoes.Matricular(a2);
            csharpColecoes.Matricular(a3);

            Console.WriteLine("Quem é o aluno com matrícula 5617?");
            Console.WriteLine(csharpColecoes.BuscarMatriculado(5617));

            Console.ReadLine();
        }

        private static void Testando_ConjuntoComObjetos()
        {
            var csharpColecoes = new Curso("C# Colecoes", "Marcelo Oliveira");

            var a1 = new Aluno("Vanessa Tonini", 34672);
            var a2 = new Aluno("Ana Losnak", 5617);
            var a3 = new Aluno("Rafael Nercessian", 17645);

            csharpColecoes.Matricular(a1);
            csharpColecoes.Matricular(a2);
            csharpColecoes.Matricular(a3);

            foreach (var aluno in csharpColecoes.Alunos)
            {
                Console.WriteLine(aluno);
            }

            Console.ReadLine();
        }

        private static void Testando_ListaSomenteLeitura()
        {
            var curso = new Curso("Estudando CSharp", "Igor Jorge");

            curso.AdicionarAula(new Aula("Lista somente leitura", 30));
            curso.AdicionarAula(new Aula("Utilizando LINQ", 30));
            curso.AdicionarAula(new Aula("Outros testes", 30));

            //Imprimir(curso.Aulas);
            Console.WriteLine(curso);

            Console.ReadLine();
        }

        private static void Testando_Conjuntos()
        {
            ///
            /// Conjuntos em C# (em inglês, Sets), existe duas regras:
            /// 
            /// 1 - Não permitir duplicidade, um elemento não será contido mais de uma vez em um mesmo conjunto.
            /// 2 - Os elementos do conjunto não são ordenados, mesmo quando adicionado ou removido.

           // declarando set de alunos
           ISet<string> alunos = new HashSet<string>();

            // adicionando: vanessa, ana, rafael
            alunos.Add("Vanessa Tonini");
            alunos.Add("Ana Losnak");
            alunos.Add("Rafael Nercessian");

            // imprimir: como outros objetos, irá imprimir seu namespace
            Console.WriteLine(alunos);

            // imprimir conteúdo do conjunto
            Console.WriteLine(string.Join(",", alunos));

            // adicionando: priscila, rollo, fabio
            alunos.Add("Priscila Stuani");
            alunos.Add("Rafael Rollo");
            alunos.Add("Fabio Gushiken");

            // imprimir: os elementos são adicionados no "final" do conjunto.
            Console.WriteLine(string.Join(",", alunos));

            // remover ana, adicionando marcelo
            alunos.Remove("Ana Losnak");
            alunos.Add("Marcelo Oliveira");

            // imprimir: o Marcel foi adicionado no lugar da Ana e não no final.
            Console.WriteLine(string.Join(",", alunos));

            // adicionando gushiken de novo
            alunos.Add("Fabio Gushiken");

            // imprimir: o gushiken não é duplicado e não ocorre erro.
            Console.WriteLine(string.Join(",", alunos));

            ///
            /// Vantagem de utilizar Conjunto e não Lista?
            ///
            /// A maior diferença em relação às listas, é que o conjunto é mais rápido na busca de elementos.
            ///
            /// Existem testes de performance entre os dois, o conjunto mantém a mesma média de tempo 
            /// independente do seu tamanho. Enquanto Lista, o tempo aumenta conforme a quantidade de elementos.
            /// ver mais em: https://stackoverflow.com/questions/150750/hashset-vs-list-performance.
            ///
            /// Concluíndo
            /// Uma Lista é mais rápido do que o Conjunto quando está utilizando poucos elementos.
        }

        private static void Imprimir(IList<Aula> aulas)
        {
            Console.Clear();
            foreach (var aula in aulas)
            {
                Console.WriteLine(aula);
            }

            Console.ReadLine();
        }
    }
}
