using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R34.ConsolidateDuplicateConditionalFragments.antes
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

            if (ehVendaPromocional)
            {
                this.precoFinal = preco * 0.95m;
                Catalogo.IncluirProduto(this);
                GerenciadorDeEmail.EnviarEmailDeNovoProduto(this);
            }
            else
            {
                this.precoFinal = preco * 0.98m;
                Catalogo.IncluirProduto(this);
                GerenciadorDeEmail.EnviarEmailDeNovoProduto(this);
            }
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
