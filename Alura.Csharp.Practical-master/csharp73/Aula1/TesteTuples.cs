using System;
using System.Collections.Generic;
using System.Text;

namespace csharp73.Aula1
{
    static class TesteTuples
    {
        public static void Igualdade1()
        {
            var origem = ("Avenida Brasil", "3006", "São Paulo");
            var destino = ("Avenida Brasil", "300", "São Paulo");

            // ANTES
            //var mesmoLugar =
            //    origem.Item1 == destino.Item1 &&
            //    origem.Item2 == destino.Item2 &&
            //    origem.Item3 == destino.Item3;

            var mesmoLugar = origem == destino;

            Console.WriteLine(mesmoLugar);
        }

        public static void Igualdade2()
        {
            // O compilador não olha o nome do parametro, mas a posição em que foi criado

            var origem = (rua: "Avenida Brasil", numero: "3006", cidade: "São Paulo");
            var destino = (numero: "300", rua: "Avenida Brasil", cidade: "São Paulo");

            var mesmoLugar = origem == destino;

            Console.WriteLine(mesmoLugar);
        }

        public static void MaisAlgunsCasos()
        {
            var ehIgual = (nome: "Pedro", idade: 15) == (nome: "Maria", idade: 12);

            // O compilador permite comparar valores do mesmo tipo, mesmo quando aceita valores nulos

            (string nome, int idade) pedro = (nome: "Pedro", idade: 15);
            (string nome, int? idade) maria = (nome: "Maria", idade: null);

            Console.WriteLine(pedro == maria);
        }
    }
}
