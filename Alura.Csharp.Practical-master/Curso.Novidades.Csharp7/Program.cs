using csharp7;
using System;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp7
{
    class Program
    {
        static string[] menus = new string[] {
            //AULA 1 - MELHORIAS EM PARÂMETROS
            "1. Variáveis out",
            "2. Locais e retornos de Ref",
            "3. Parâmetros in",
            "4. Argumentos Nomeados",
            //AULA 2 - TUPLAS
            "5. Tuplas",
            "6. Descartes",
            //AULA 3 - MELHORIAS EM CONDICIONAIS
            "7. Correspondência de Padrões",
            "8. Expressões Throw",
            //AULA 4 - LITERAIS E VALORES PADRÃO
            "9. Aprimoramentos da Sintaxe de Literais Numéricos",
            "10. Async Main",
            "11. Expressão Literal Padrão",
            //AULA 5 - ESTILO DE CÓDIGO
            "12. Funções Locais",
            "13. Mais Membros com Corpo de Expressão",
            "14. Estilo de Código"
        };

        //static async Task<int> Main(string[] args)
        static void Main(string[] args)
        {
            //try
            //{
            //    Console.WriteLine(await csharp7.R10.depois.MenuItem.GetGoogleAsync());
            //}
            //catch (Exception exc)
            //{
            //    Console.WriteLine(exc.ToString());
            //    return 1;
            //}

            //Console.ReadKey();
            //return 0;

            WriteLine("ÍNDICE DE PROGRAMAS");
            WriteLine("===================");

            string line;
            do
            {
                foreach (var menu in menus)
                {
                    WriteLine(menu);
                }

                WriteLine();
                WriteLine("Escolha um programa:");

                line = ReadLine();

                Int32.TryParse(line, out int programa);

                Executar(programa);

                WriteLine();
                WriteLine("PRESSIONE UMA TECLA PARA CONTINUAR...");
                ReadKey();
                Clear();
            } while (line.Length > 0);
        }

        private static void Executar(int programa)
        {
            if (programa > 0)
            {
                ImprimirTitulo(programa);
                ForegroundColor = ConsoleColor.Green;
                ExecutarPasso(programa, "antes");
                ForegroundColor = ConsoleColor.Yellow;
                ExecutarPasso(programa, "depois");
                ForegroundColor = ConsoleColor.White;
            }
        }

        private static void ImprimirTitulo(int programa)
        {
            WriteLine();
            WriteLine(menus[programa - 1]);
            WriteLine();
        }

        private static void ExecutarPasso(int programa, string step)
        {
            WriteLine(step.ToUpper());
            WriteLine(new string('=', 100));
            var type = Type.GetType($"csharp7.R{programa:00}.{step}.MenuItem");
            ((MenuItem)Activator.CreateInstance(type)).Main();
            WriteLine();
        }
    }
}
