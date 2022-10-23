using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R36.ReplaceNestedConditional.depois
{
    class Programa
    {
        void Main()
        {
            var auxilio = new Auxilio(1000, 800, 700, 500, false, true, true);
            Console.WriteLine($"Pagamento do auxílio: {auxilio.GetPagamento()}");
        }
    }

    class Auxilio
    {
        private readonly double valorNormal;
        private double ValorNormal => valorNormal;

        private readonly double valorAposentado;
        private double ValorAposentado => valorAposentado;

        private readonly double valorSeparado;
        private double ValorSeparado => valorSeparado;

        private readonly double valorFalecido;
        private double ValorFalecido => valorFalecido;

        private readonly bool ehFalecido;
        private readonly bool ehSeparado;
        private readonly bool ehAposentado;

        public Auxilio(double valorNormal,
            double valorAposentado,
            double valorSeparado,
            double valorFalecido,
            bool ehFalecido, bool ehSeparado, bool ehAposentado)
        {
            this.valorNormal = valorNormal;
            this.valorAposentado = valorAposentado;
            this.valorSeparado = valorSeparado;
            this.valorFalecido = valorFalecido;
            this.ehFalecido = ehFalecido;
            this.ehSeparado = ehSeparado;
            this.ehAposentado = ehAposentado;
        }

        public double GetPagamento()
        {
            if (ehFalecido)
            {
                return ValorFalecido; //early return
            }

            if (ehSeparado)
            {
                return ValorSeparado; //early return
            }

            if (ehAposentado)
            {
                return ValorAposentado;//early return
            }
            return ValorNormal;
        }
    }
}
