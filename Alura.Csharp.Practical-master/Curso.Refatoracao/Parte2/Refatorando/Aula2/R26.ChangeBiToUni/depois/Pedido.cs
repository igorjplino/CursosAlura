using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace refatoracao.R26.ChangeBiToUni.depois
{
    class Program
    {
        void Main()
        {
            var cliente = new Cliente();

            Pedido pedido = cliente.AdicionaPedido();
            cliente.RemovePedido(pedido);

            //acessando pedidos a partir do cliente
            foreach (var p in cliente.Pedidos)
            {
                Console.WriteLine($"Pedido: {pedido}");
            }
        }
    }

    class Pedido
    {

    }

    class Cliente
    {
        private IList<Pedido> pedidos = new List<Pedido>();
        public IReadOnlyCollection<Pedido> Pedidos
        {
            get { return new ReadOnlyCollection<Pedido>(pedidos); }
        }

        internal Pedido AdicionaPedido()
        {
            Pedido pedido = new Pedido();
            pedidos.Add(pedido);
            return pedido;
        }

        internal void RemovePedido(Pedido pedido)
        {
            pedidos.Remove(pedido);
        }

        //Mais código do cliente aqui...
    }
}
