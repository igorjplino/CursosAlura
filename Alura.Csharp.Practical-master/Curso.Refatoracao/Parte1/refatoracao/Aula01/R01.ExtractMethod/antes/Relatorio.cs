using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace refatoracao.Aula01.R01.ExtractMethod.antes
{
    class Relatorio
    {
        void Imprimir()
        {
            decimal total = 0.0m;
            var pedido = new Pedido("José da Silva");
            pedido.AddItem("Dentozap", 2, 10m, 0m, 3m);
            pedido.AddItem("Voldax", 3, 10m, 0m, 3m);
            pedido.AddItem("Tranlab", 7, 10m, 0m, 3m);

            // imprimir itens
            Console.WriteLine("*****************************");
            Console.WriteLine("********** Itens ************");
            Console.WriteLine("*****************************");
            foreach (var item in pedido.Itens)
            {
                decimal valorItem = item.Quantidade * item.PrecoBase;
                Console.WriteLine($"{item.Desconto}: {item.Quantidade} unidades, R$ {valorItem}");
                total = total + valorItem;
            }

            // imprimir detalhes
            Console.WriteLine("*****************************");
            Console.WriteLine("********** Resumo************");
            Console.WriteLine("*****************************");
            Console.WriteLine("nome: " + pedido.Cliente);
            Console.WriteLine("valor: " + total);
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
