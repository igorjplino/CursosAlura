using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace refatoracao.R20.ReplaceDataValueWithObject.depois
{
    class Exemplo
    {
        void Teste()
        {
            var cliente = new Cliente("José da Silva");

            var pedido1 = new Pedido(cliente);
            pedido1.AddItem("Alphakix", 10, 3);
            pedido1.AddItem("Stocklab", 15, 5);
            pedido1.AddItem("Statstrong", 6, 2);

            var pedido2 = new Pedido(cliente);
            pedido2.AddItem("Fluxon", 5, 4);
            pedido2.AddItem("Uptron", 6, 5);
            pedido2.AddItem("Fillflix", 2, 4);

            IList<Pedido> pedidos = new List<Pedido> { pedido1, pedido2 };

            decimal comprasTotaisCliente = cliente.TotalCompras;
        }
    }

    class Pedido
    {
        private readonly Cliente cliente;
        public Cliente Cliente { get; }

        private readonly IList<Item> itens = new List<Item>();
        public IReadOnlyCollection<Item> Itens => new ReadOnlyCollection<Item>(itens);

        public Pedido(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public void AddItem(string produto, decimal precoUnitario, int quantidade)
        {
            Item item = new Item(produto, precoUnitario, quantidade);
            itens.Add(item);

            cliente.AddItem(item);
        }

        public void RemoveItem(string produto)
        {
            var item = itens.Where(i => i.Produto.Equals(produto, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
            if (item != null)
            {
                itens.Remove(item);
            }

            cliente.RemoveItem(item);
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

    class Cliente
    {
        readonly string nome;
        decimal totalCompras;

        public Cliente(string nome)
        {
            this.nome = nome;
        }

        public string Nome => nome;

        public decimal TotalCompras { get => totalCompras; }

        internal void AddItem(Item item)
        {
            totalCompras += item.Total;
        }

        internal void RemoveItem(Item item)
        {
            totalCompras -= item.Total;
        }
    }
}
