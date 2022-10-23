using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp73.Aula2
{
    class AplicacaoWeb
    {
        public static string Porta = "8080";

        // Até a versão 7.2 essa expressão não era permitida
        public static bool EstaRodandoEmPortaAlta =
            int.TryParse(Porta, out int portaComoInt) && portaComoInt > 1024;
    }

    public static class ExpressionVariables
    {
        public static bool ValidaIdade(string idadeComoTexto) =>
            int.TryParse(idadeComoTexto, out int idade) && idade > 18;

        public static void TestaExpressionVariables()
        {
            var idadeComoTexto = "15";

            if (int.TryParse(idadeComoTexto, out int idade) && idade > 18)
            {
                Console.WriteLine("Permitida a entrada");
            }
        }

        public static void RegistroDeAlunos()
        {
            var alunos = new string[]
            {
                "1000", "1001", "1002",
                "1003", "1004T", "1005Y"
            };

            var alunosValidos =
                from ra in alunos
                where int.TryParse(ra, out int raComoInt) && raComoInt > 1000
                select ra + " é válido";

            /// não é possível utilizar a variável 'raComoInt' dentro do scopo do 'select'
            /// pq quando o código é compilado, é criada uma função para condição 'where' 
            /// e a variável 'raComoInt' não existe fora dessa função
            //var alunosValidos =
            //    from ra in alunos
            //    where int.TryParse(ra, out int raComoInt) && raComoInt > 1000
            //    select raComoInt;
        }
    }
}
