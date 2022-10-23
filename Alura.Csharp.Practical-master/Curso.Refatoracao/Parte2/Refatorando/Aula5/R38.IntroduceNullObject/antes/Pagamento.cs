using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R38.IntroduceNullObject.antes
{
    class Programa
    {
        void Main()
        {
            Pagamento pagamento;

            pagamento = new Pagamento(new CartaoCredito(), 1000, 3);
            pagamento.Pagar();

            pagamento = new Pagamento(new CartaoDebito(), 2000, 1);
            pagamento.Pagar();

            pagamento = new Pagamento(new ValePresente(), 500, 1);
            pagamento.Pagar();

            pagamento = new Pagamento(null, 200, 1); //em dinheiro!
            pagamento.Pagar();

            Console.ReadKey();
        }
    }

    abstract class Cartao
    {
        public abstract void EfetuarPagamento(decimal valor, int parcelas);
        public abstract void EstornarPagamento(decimal valor, int parcelas);
    }

    class CartaoCredito : Cartao
    {

        public override void EfetuarPagamento(decimal valor, int parcelas)
        {
            Console.WriteLine(
              "Fazendo pagamento em Cartao de Credito");
        }

        public override void EstornarPagamento(decimal valor, int parcelas)
        {
            Console.WriteLine(
              "Estornando pagamento em Cartao de Credito");
        }
    }

    class CartaoDebito : Cartao
    {
        public override void EfetuarPagamento(decimal valor, int parcelas)
        {
            Console.WriteLine(
              "Fazendo pagamento em Cartao de Debito");
        }

        public override void EstornarPagamento(decimal valor, int parcelas)
        {
            Console.WriteLine(
              "Estornando pagamento em Cartao de Debito");
        }
    }

    class ValePresente : Cartao
    {
        public override void EfetuarPagamento(decimal valor, int parcelas)
        {
            Console.WriteLine(
              "Fazendo pagamento em Vale Presente");
        }

        public override void EstornarPagamento(decimal valor, int parcelas)
        {
            Console.WriteLine(
              "Estornando pagamento em Vale Presente");
        }
    }

    class Pagamento
    {
        private readonly Cartao cartao;
        private readonly decimal valor;
        private readonly int parcelas;

        public Pagamento(Cartao cartao, decimal valor, int parcelas)
        {
            this.cartao = cartao;
            this.valor = valor;
            this.parcelas = parcelas;
        }

        public void Pagar()
        {
            if (cartao != null) // temos que verificar nulo várias vezes
            {
                cartao.EfetuarPagamento(valor, parcelas);
            }
            else
            {
                AbrirCaixaRegistradora();
                EfetuarPagamentoEmDinheiro(valor);
                FecharCaixaRegistradora();
            }
        }

        public void Estornar()
        {
            if (cartao != null) // temos que verificar nulo várias vezes
            {
                cartao.EstornarPagamento(valor, parcelas);
            }
            else
            {
                AbrirCaixaRegistradora();
                EstornarPagamentoEmDinheiro(valor);
                FecharCaixaRegistradora();
            }
        }

        private void AbrirCaixaRegistradora()
        {
            Console.WriteLine("Abrindo Caixa Registradora...");
        }

        private void FecharCaixaRegistradora()
        {
            Console.WriteLine("Fechando Caixa Registradora...");
        }

        private void EfetuarPagamentoEmDinheiro(decimal valor)
        {
            Console.WriteLine("Fazendo pagamento em dinheiro...");
        }

        private void EstornarPagamentoEmDinheiro(decimal valor)
        {
            Console.WriteLine("Estornando Pagamento Em Dinheiro...");
        }
    }
}
