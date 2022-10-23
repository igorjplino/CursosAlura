using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R17.IntroduceLocalExtension.antes
{
    class Exemplo
    {
        public Exemplo()
        {
            var data = DateTime.Today;
            var ultimoDiaDoMes = UltimoDiaDoMes(data);
            var primeiroDiaDoMes = PrimeiroDiaDoMes(data);
            var ehFimDeSemana = EhFimDeSemana(data);
        }

        private DateTime PrimeiroDiaDoMes(DateTime data)
        {
            return new DateTime(data.Year, data.Month, 1);
        }

        private DateTime UltimoDiaDoMes(DateTime data)
        {
            return new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
        }

        private bool EhFimDeSemana(DateTime data)
        {
            return data.DayOfWeek == DayOfWeek.Saturday 
                || data.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
