using System;
using System.Collections.Generic;
using System.Text;

namespace csharp73.Aula5
{
    class DeInstanciaOuEstatico
    {
        public void TestaSobrecarga()
        {
            EscreverMensagem(1);

            /// Na 7.3, o compilador consegue diferenciar sobrecargas de instancia e estatico 
            /// quando o parametro não diz explicitamente qual utilizar
            this.EscreverMensagem(null);
            DeInstanciaOuEstatico.EscreverMensagem(null);
        }

        private void EscreverMensagem(StringBuilder texto)
        {
            Console.WriteLine(texto);
        }

        private static void EscreverMensagem(string texto)
        {
            Console.WriteLine(texto);
        }

        private void EscreverMensagem(int numero)
        {
            Console.WriteLine(numero);
        }
    }

    class MelhoriaEmSobrecargaDeMetodoGenerico
    {
        /// Na 7.3, o compilador consegue resolver métodos genéricos com restrições.
        /// Nas versões anteriores, ele daria erro de compilação, mas o método com parametro 'short' deveria ser utilizado,
        /// pois o valor 2 também cabe na definição do 'short'

        public void TestaMelhoria()
        {
            EscreveMensagem("teste", 2);
            EscreveMensagem("teste", 2.0);

            short a = 2;
            EscreveMensagem("teste", a);
        }

        public void EscreveMensagem<T>(T objeto, int numero) where T : IDisposable
        {
            Console.WriteLine(objeto);
        }

        public void EscreveMensagem<T>(T objeto, double numero)
        {
            Console.WriteLine(objeto);
        }

        public void EscreveMensagem<T>(T objeto, short numero)
        {
            Console.WriteLine(objeto);
        }
    }

    class MelhoriaEmSobrecargaDeDelegates
    {
        /// Na 7.3 o compilador consegue resolver sobrecargas de Delegates.
        /// Nas anteriores, o compilador não consegue resolver a sobrecarga para o Delegate 'EscreveMensagem',
        /// mesmo comentando a sobrecarga que aceita Action, a que aceita Func não resolve o Delegate 'EscreveMensagem'.

        public void Teste()
        {
            TestaDelegate(int.Parse);
            TestaDelegate(EscreveMensagem);
        }

        public void TestaDelegate(Func<string, int> func) => Console.WriteLine("func");

        public void TestaDelegate(Action<string> action) => Console.WriteLine("action");

        public void EscreveMensagem(string a) => Console.WriteLine(a);
    }
}
