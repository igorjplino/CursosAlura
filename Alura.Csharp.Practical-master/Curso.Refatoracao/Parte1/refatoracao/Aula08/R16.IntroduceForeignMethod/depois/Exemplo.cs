using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R16.IntroduceForeignMethod.depois
{
    class Exemplo
    {
        public Exemplo()
        {
            var data = DateTime.Today;
            var ultimoDiaDoMes = GetUltimoDiaDoMes(data);
        }

        private static DateTime GetUltimoDiaDoMes(DateTime data)
        {
            return new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
        }
    }
}
