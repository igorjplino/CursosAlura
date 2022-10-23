using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            ///
            /// Stack ou Pilha
            /// 
            /// Último a entrar, primeiro a sair.
            /// LIFO = last-in-first-out

            var navegador = new Navegador();

            navegador.NavegarPara("google.com");
            navegador.NavegarPara("caelum.com.br");
            navegador.NavegarPara("alura.com.br");

            navegador.Anterior();
            navegador.Anterior();
            navegador.Anterior();
            navegador.Anterior();

            navegador.Proximo();
            navegador.Proximo();
            navegador.Proximo();
            navegador.Proximo();
            navegador.Proximo();

            Console.ReadLine();
        }
    }

    internal class Navegador
    {
        private readonly Stack<string> historicoAnterior = new Stack<string>();
        private readonly Stack<string> historicoProximo = new Stack<string>();

        private string atual = "vazia";

        public Navegador()
        {
            Navegar();
        }

        internal void NavegarPara(string url)
        {
            historicoAnterior.Push(atual);
            atual = url;

            Navegar();
        }

        internal void Anterior()
        {
            if (historicoAnterior.Any())
            {
                historicoProximo.Push(atual);
                atual = historicoAnterior.Pop();
                
                Navegar();
            }
        }

        internal void Proximo()
        {
            if (historicoProximo.Any())
            {
                historicoAnterior.Push(atual);
                atual = historicoProximo.Pop();

                Navegar();
            }
        }

        private void Navegar()
        {
            Console.WriteLine("Página atual: " + atual);
        }
    }
}
