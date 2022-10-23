using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R34.ConsolidateDuplicateConditionalFragments.depois
{
    class Programa
    {
        void Main()
        {
            var produto = new Produto(100, false);
            Console.WriteLine($"Preco final: {produto.PrecoFinal}");
        }
    }

    class Produto
    {
        private const decimal FATOR_DESCONTO_PROMOCIONAL = 0.95m;
        private const decimal FATOR_DESCONTO_NORMAL = 0.98m;
        readonly decimal preco;
        public decimal Preco => preco;

        decimal precoFinal;
        public decimal PrecoFinal => precoFinal;

        readonly bool ehVendaPromocional;
        public bool EhVendaPromocional => ehVendaPromocional;

        public Produto(decimal preco, bool ehVendaPromocional)
        {
            this.preco = preco;
            this.ehVendaPromocional = ehVendaPromocional;

            this.precoFinal = preco * GetFatorDesconto(ehVendaPromocional);

            Catalogo.IncluirProduto(this);
            GerenciadorDeEmail.EnviarEmailDeNovoProduto(this);

        }

        private static decimal GetFatorDesconto(bool ehVendaPromocional)
        {
            if (ehVendaPromocional)
            {
                return FATOR_DESCONTO_PROMOCIONAL; //early return
            }
            return FATOR_DESCONTO_NORMAL;
        }
    }

    class GerenciadorDeEmail
    {
        public static void EnviarEmailDeNovoProduto(Produto produto)
        {
            //Aqui vai o código para enviar
            //email de lançamento de novo produto...
        }
    }

    class Catalogo
    {
        public static void IncluirProduto(Produto produto)
        {
            //Aqui vai o código para criar novo produto...
        }
    }
}
