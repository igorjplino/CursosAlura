using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static Queue<string> pedagio = new Queue<string>();

        static void Main(string[] args)
        {
            ///
            /// Queue ou Fila
            /// 
            /// Primeiro a entrar, é o primeiro a sair.
            /// FIFO = first-in-first-out

            Enfileirar("van");
            Enfileirar("kombi");
            Enfileirar("guincho");
            Enfileirar("pickup");
            
            Desenfileirar();
            Desenfileirar();
            Desenfileirar();
            Desenfileirar();
            Desenfileirar();

            Console.ReadLine();
        }

        private static void Enfileirar(string veiculo)
        {
            Console.WriteLine($"Entrou na fila: {veiculo}");
            pedagio.Enqueue(veiculo);
            ImprimirFila();
        }

        private static void Desenfileirar()
        {
            if (pedagio.Any())
            {
                if (pedagio.Peek() == "guincho")
                {
                    Console.WriteLine("guincho está fazendo o pagamento.");
                }

                string veiculo = pedagio.Dequeue();
                Console.WriteLine($"Saiu da fila: {veiculo}");

                ImprimirFila();
            }
        }

        private static void ImprimirFila()
        {
            Console.WriteLine("FILA:");
            foreach (var carro in pedagio)
            {
                Console.WriteLine(carro);
            }

            Console.WriteLine();
        }
    }
}
