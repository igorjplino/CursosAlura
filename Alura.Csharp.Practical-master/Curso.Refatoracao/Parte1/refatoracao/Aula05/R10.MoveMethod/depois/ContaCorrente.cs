using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R10.MoveMethod.depois
{
    class ContaCorrente
    {
        public decimal GetTaxaChequeEspecial()
        {
            return tipo.GetTaxaChequeEspecial(this);
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

        public decimal GetTaxaChequeEspecial(ContaCorrente conta)
        {
            if (this.EhPremium)
            {
                var result = 10.0M;
                if (conta.DiasEmDescoberto > 7)
                {
                    result += (conta.DiasEmDescoberto - 7) * 0.01M;
                }
                return result;
            }

            return conta.DiasEmDescoberto * 1.75M;
        }
    }
}
