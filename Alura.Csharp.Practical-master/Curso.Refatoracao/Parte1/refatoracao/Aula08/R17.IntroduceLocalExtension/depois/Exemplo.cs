using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R17.IntroduceLocalExtension.depois
{
    class Exemplo
    {
        public Exemplo()
        {
            var data = DateTime.Today;
            var ultimoDiaDoMes = data.UltimoDiaDoMes();
            var primeiroDiaDoMes = data.PrimeiroDiaDoMes();
            var ehFimDeSemana = data.EhFimDeSemana();
        }
    }

    static class DateTimeExtensions
    {
        public static DateTime PrimeiroDiaDoMes(this DateTime data)
        {
            return new DateTime(data.Year, data.Month, 1);
        }

        public static DateTime UltimoDiaDoMes(this DateTime data)
        {
            return new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
        }

        public static bool EhFimDeSemana(this DateTime data)
        {
            return data.DayOfWeek == DayOfWeek.Saturday
                || data.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
