using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {
        ItemPedido GetItemPedido(int itemPedidoId);
        void RemoveItemPedido(int itemPedidoId);
    }
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto)
            : base(contexto)
        {
        }

        public ItemPedido GetItemPedido(int itemPedidoId)
        {
            return dbSet.SingleOrDefault(ip => ip.Id == itemPedidoId);
        }

        public void RemoveItemPedido(int itemPedidoId)
        {
            dbSet.Remove(GetItemPedido(itemPedidoId));
        }
    }
}
