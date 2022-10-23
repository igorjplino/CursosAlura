using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace refatoracao.Aula01.R01.ExtractMethod.depois
{
    class Relatorio
    {
        void Imprimir()
        {
            Pedido pedido = CriarPedido();
            decimal total = ImprimirItens(pedido);
            ImprimirDetalhes(pedido, total);
        }

        private static Pedido CriarPedido()
        {
            var pedido = new Pedido("José da Silva");
            pedido.AddItem("Dentozap", 2, 10m, 0m, 3m);
            pedido.AddItem("Voldax", 3, 10m, 0m, 3m);
            pedido.AddItem("Tranlab", 7, 10m, 0m, 3m);
            return pedido;
        }

        private static void ImprimirDetalhes(Pedido pedido, decimal total)
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("********** Resumo************");
            Console.WriteLine("*****************************");
            Console.WriteLine("nome: " + pedido.Cliente);
            Console.WriteLine("valor: " + total);
        }

        private static decimal ImprimirItens(Pedido pedido)
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("********** Itens ************");
            Console.WriteLine("*****************************");
            decimal total = 0.0m;
            foreach (var item in pedido.Itens)
            {
                decimal valorItem = GetValorItem(item);
                Console.WriteLine($"{item.Desconto}: {item.Quantidade} unidades, R$ {valorItem}");
                total = total + valorItem;
            }

            return total;
        }

        private static decimal GetValorItem(Item item)
        {
            return item.Quantidade * item.PrecoBase;
        }
    }

    class Pedido
    {
        private readonly IList<Item> itens = new List<Item>();
        public IReadOnlyCollection<Item> Itens
        {
            get { return new ReadOnlyCollection<Item>(itens); }
        }

        private readonly string cliente;
        public string Cliente { get => cliente; }

        public Pedido(string cliente)
        {
            this.cliente = cliente;
        }

        public void AddItem(string descricao, int quantidade, decimal precoBase, decimal acrescimo, decimal desconto)
        {
            itens.Add(new Item(descricao, quantidade, precoBase, acrescimo, desconto));
        }
    }

    class Item
    {
        private readonly string descricao;
        private readonly int quantidade;
        private readonly decimal precoBase;
        private readonly decimal acrescimo;
        private readonly decimal desconto;

        public string Descricao { get => descricao; }
        public int Quantidade { get => quantidade; }
        public decimal PrecoBase { get => precoBase; }
        public decimal Acrescimo { get => acrescimo; }
        public decimal Desconto { get => desconto; }

        public Item(string descricao, int quantidade, decimal precoBase, decimal acrescimo, decimal desconto)
        {
            this.descricao = descricao;
            this.quantidade = quantidade;
            this.precoBase = precoBase;
            this.acrescimo = acrescimo;
            this.desconto = desconto;
        }
    }
}
