using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R38.IntroduceNullObject.depois
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

    class Dinheiro : Cartao
    {
        public override void EfetuarPagamento(decimal valor, int parcelas)
        {
            AbrirCaixaRegistradora();
            EfetuarPagamentoEmDinheiro(valor);
            FecharCaixaRegistradora();
        }

        public override void EstornarPagamento(decimal valor, int parcelas)
        {
            AbrirCaixaRegistradora();
            EstornarPagamentoEmDinheiro(valor);
            FecharCaixaRegistradora();
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
            if (cartao == null)
            {
                this.cartao = new Dinheiro();
            }
            else
            {
                this.cartao = cartao;
            }
            this.valor = valor;
            this.parcelas = parcelas;
        }

        public void Pagar()
        {
            cartao.EfetuarPagamento(valor, parcelas);
        }

        public void Estornar()
        {
            cartao.EstornarPagamento(valor, parcelas);
        }
    }
}
