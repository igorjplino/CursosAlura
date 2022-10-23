using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R36.ReplaceNestedConditional.antes
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
            double result;

            if (ehFalecido)
            {
                result = ValorFalecido;
            }
            else
            {
                if (ehSeparado)
                {
                    result = ValorSeparado;
                }
                else
                {
                    if (ehAposentado)
                    {
                        result = ValorAposentado;
                    }
                    else
                    {
                        result = ValorNormal;
                    }
                }
            }

            return result;
        }
    }
}
