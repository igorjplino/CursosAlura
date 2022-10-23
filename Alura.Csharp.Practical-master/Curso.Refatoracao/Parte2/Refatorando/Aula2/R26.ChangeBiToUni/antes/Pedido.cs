using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace refatoracao.R26.ChangeBiToUni.antes
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
        private Cliente cliente;
        internal Cliente Cliente { get => cliente; }

        public Pedido(Cliente cliente)
        {
            this.cliente = cliente;
        }

        internal void RemoveCliente()
        {
            cliente = null;
        }
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
            Pedido pedido = new Pedido(this);
            pedidos.Add(pedido);
            return pedido;
        }

        internal void RemovePedido(Pedido pedido)
        {
            pedidos.Remove(pedido);
            pedido.RemoveCliente();
        }

        //Mais código do cliente aqui...
    }
}
