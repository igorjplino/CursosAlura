using System;

namespace refatoracao.R28.ReplaceTypeCodeWithClass.antes
{
    class Programa
    {
        public void Main()
        {
            var minhaContaCorrente = new ContaBancaria(ContaBancaria.CONTA_CORRENTE, 100m);
            var minhaPoupanca = new ContaBancaria(ContaBancaria.POUPANCA, 300m);
            var meuInvestimento = new ContaBancaria(ContaBancaria.INVESTIMENTO, 1500m);

            minhaContaCorrente.Depositar(100);
            minhaContaCorrente.Sacar(75);

            minhaPoupanca.Depositar(55);
            minhaPoupanca.Sacar(16);

            meuInvestimento.Depositar(40);
            meuInvestimento.Sacar(30);
        }
    }

    class ContaBancaria
    {
        public static int CONTA_CORRENTE = 0;
        public static int POUPANCA = 1;
        public static int INVESTIMENTO = 2;
        
        private readonly int tipoConta;
        public int TipoConta
        {
            get
            {
                return tipoConta;
            }
        }

        private decimal saldo;
        public decimal Saldo
        {
            get
            {
                return saldo;
            }
        }

        public ContaBancaria(int tipoConta, decimal saldoInicial)
        {
            this.tipoConta = tipoConta;
            this.saldo = saldoInicial;
        }

        public void Sacar(decimal valor)
        {
            if (valor > Saldo)
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
