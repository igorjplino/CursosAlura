using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace refatoracao.R25.ChangeUniToBi.antes
{
    class Program
    {
        void Main()
        {
            var cliente = new Cliente();
            var pedido = new Pedido();

            cliente.AdicionaPedido(pedido);
            cliente.RemovePedido(pedido);

            //acessando pedidos a partir do cliente
            foreach (var p in cliente.Pedidos)
            {
                Console.WriteLine($"Pedido: {pedido}");
            }

            //acessando cliente a partir do pedido (não é possível!)
            //Console.WriteLine($"Cliente: {pedido.Cliente}");
        }
    }

    class Pedido
    {
        //Código do pedido aqui...
    }

    class Cliente
    {
        private IList<Pedido> pedidos = new List<Pedido>();
        public IReadOnlyCollection<Pedido> Pedidos
        {
            get { return new ReadOnlyCollection<Pedido>(pedidos); }
        }

        internal void AdicionaPedido(Pedido pedido)
        {
            pedidos.Add(pedido);
        }

        internal void RemovePedido(Pedido pedido)
        {
            pedidos.Remove(pedido);
        }

        //Mais código do cliente aqui...
    }
}
