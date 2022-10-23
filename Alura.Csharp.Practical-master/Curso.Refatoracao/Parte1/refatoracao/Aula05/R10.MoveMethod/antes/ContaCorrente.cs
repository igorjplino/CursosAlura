using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R10.MoveMethod.antes
{
    class ContaCorrente
    {
        public decimal GetTaxaChequeEspecial()
        {
            if (tipo.EhPremium)
            {
                var result = 10.0M;
                if (this.diasEmDescoberto > 7)
                {
                    result += (diasEmDescoberto - 7) * 0.01M;
                }
                return result;
            }

            return diasEmDescoberto * 1.75M;
        }

        public ContaCorrente(TipoConta type)
        {
            this.tipo = type;
        }

        private readonly TipoConta tipo;
        public TipoConta Tipo { get { return tipo; } }

        private int diasEmDescoberto;
        public int DiasEmDescoberto
        {
            get { return diasEmDescoberto; }
        }
    }

    class TipoConta
    {
        public bool EhPremium { get; set; }
    }
}
