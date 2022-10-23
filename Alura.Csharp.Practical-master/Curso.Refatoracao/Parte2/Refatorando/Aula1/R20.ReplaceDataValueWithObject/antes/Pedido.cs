using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace refatoracao.R20.ReplaceDataValueWithObject.antes
{
    class Exemplo
    {
        void Teste()
        {
            var pedido1 = new Pedido("José da Silva");
            pedido1.AddItem("Alphakix", 10, 3);
            pedido1.AddItem("Stocklab", 15, 5);
            pedido1.AddItem("Statstrong", 6, 2);

            var pedido2 = new Pedido("José da Silva");
            pedido2.AddItem("Fluxon", 5, 4);
            pedido2.AddItem("Uptron", 6, 5);
            pedido2.AddItem("Fillflix", 2, 4);

            IList<Pedido> pedidos = new List<Pedido> { pedido1, pedido2 };

            decimal comprasTotaisCliente =
                pedidos
                .Where(p => p.Cliente.Equals("José da Silva"))
                .Sum(p => p.Itens.Sum(i => i.Total));
        }
    }

    class Pedido
    {
        private readonly string cliente;
        public string Cliente { get; }

        private readonly IList<Item> itens = new List<Item>();
        public IReadOnlyCollection<Item> Itens => new ReadOnlyCollection<Item>(itens);

        public Pedido(string cliente)
        {
            this.cliente = cliente;
        }

        public void AddItem(string produto, decimal precoUnitario, int quantidade)
        {
            itens.Add(new Item(produto, precoUnitario, quantidade));
        }

        public void RemoveItem(string produto)
        {
            var item = itens.Where(i => i.Produto.Equals(produto, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
            if (item != null)
            {
                itens.Remove(item);
            }
        }
    }

    class Item
    {
        readonly string produto;
        public string Produto => produto;

        readonly decimal precoUnitario;
        public decimal PrecoUnitario => precoUnitario;

        readonly int quantidade;
        public int Quantidade => quantidade;

        public decimal Total => precoUnitario * quantidade;

        public Item(string produto, decimal precoUnitario, int quantidade)
        {
            this.produto = produto;
            this.precoUnitario = precoUnitario;
            this.quantidade = quantidade;
        }
    }
}
