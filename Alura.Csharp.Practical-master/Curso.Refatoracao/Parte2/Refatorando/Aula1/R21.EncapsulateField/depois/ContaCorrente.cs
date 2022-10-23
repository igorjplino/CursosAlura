using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R21.EncapsulateField.depois
{
    class Programa
    {
        void Main()
        {
            var conta = new ContaCorrente();
            conta.Depositar(100);
            conta.Sacar(75);
            //conta.saldo -= 35; //opa, acessou diretamente o saldo!!
        }
    }

    class ContaCorrente
    {
        private decimal saldo;

        public decimal Saldo { get => saldo; }

        public void Sacar(decimal valor)
        {
            if (valor > saldo)
            {
                throw new ArgumentException("Saldo insuficiente");
            }

            this.saldo -= valor;
        }

        public void Depositar(decimal valor)
        {
            this.saldo += valor;
        }
    }
}
