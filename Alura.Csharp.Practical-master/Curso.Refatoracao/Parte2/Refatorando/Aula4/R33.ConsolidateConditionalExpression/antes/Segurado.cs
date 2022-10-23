using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R33.ConsolidateConditionalExpression.antes
{
    class Programa
    {
        void Main()
        {
            var segurado = new Segurado();
            segurado.CumprindoCarencia = true;
            segurado.MensalidadesAtrasadas = 2;
            segurado.MesesSemSinistro = 3;

            Console.WriteLine($"Valor do seguro: {segurado.ValorSeguroAReceber()}");
        }
    }

    class Segurado
    {
        bool cumprindoCarencia;
        public bool CumprindoCarencia
        {
            get => cumprindoCarencia;
            set => cumprindoCarencia = value;
        }

        int mensalidadesAtrasadas;
        public int MensalidadesAtrasadas
        {
            get => mensalidadesAtrasadas;
            set => mensalidadesAtrasadas = value;
        }

        int mesesSemSinistro;
        public int MesesSemSinistro
        {
            get => mesesSemSinistro;
            set => mesesSemSinistro = value;
        }

        public decimal ValorSeguroAReceber()
        {
            if (cumprindoCarencia) return 0; // early return
            if (mensalidadesAtrasadas > 1) return 0; // early return
            if (mesesSemSinistro < 12) return 0; // early return

            decimal resultado = 0;

            //
            //Aqui é calculado o valor do seguro...
            //
            return resultado;
        }
    }
}
