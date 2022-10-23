using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

namespace csharp7.R07.depois
{
    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            Console.WriteLine("Calculadora Para Somar Qualquer Tipo");
            Console.WriteLine("====================================");
            Console.WriteLine();

            var calculadora = new Calculadora();
            calculadora.Somar(2); //int
            calculadora.Somar(3.0m); //decimal
            calculadora.Somar(3.0); //double
            calculadora.Somar(new int[] { 4, 5, 6 });
            calculadora.Somar(new decimal[] { 4.1m, 5.2m, 6.3m });
            calculadora.Somar(new double[] { 4.1, 5.2, 6.3 });
            calculadora.Somar("20");
            calculadora.Somar("R$ 20");
            calculadora.Somar("[20]");
            calculadora.Somar(new object[] { "20", 100, 150m, 24.0, "R$ 12,34" });
        }
    }

    class Calculadora
    {
        private const string NUMERO_ENTRE_COLCHETES = @"\[(\d+)\]";

        public double Soma { get; private set; } = 0d;

        public void Somar(object parametro)
        {
            var cultura = new CultureInfo("pt-BR");

            switch (parametro)
            {
                case double valorDouble:
                    Console.WriteLine($"Total anterior: {Soma}");
                    Console.WriteLine($"Somando: {valorDouble}");
                    Soma += valorDouble;
                    Console.WriteLine($"Total atual: {Soma}");
                    Console.WriteLine();
                    break;
                case int valorInt:
                    Somar((double)valorInt);
                    break;
                case decimal valorDecimal:
                    Somar((double)valorDecimal);
                    break;
                case string str when Regex.Match(str, NUMERO_ENTRE_COLCHETES).Success:
                    Somar(Regex.Match(str, NUMERO_ENTRE_COLCHETES).Groups[1].Value);
                    break;
                case string _ when double.TryParse(parametro.ToString(), NumberStyles.Currency, cultura.NumberFormat, out var valorDouble):
                    { Somar(valorDouble); }
                    break;
                case IEnumerable<object> colecao:
                    foreach (var item in colecao) Somar(item);
                    break;
                case IEnumerable<int> colecao:
                    foreach (var item in colecao) Somar(item);
                    break;
                case IEnumerable<decimal> colecao:
                    foreach (var item in colecao) Somar(item);
                    break;
                case IEnumerable<double> colecao:
                    foreach (var item in colecao) Somar(item);
                    break;
                default:
                    break;
            }
        }
    }
}
