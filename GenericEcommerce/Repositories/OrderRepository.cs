using GenericEcommerce.Context;
using GenericEcommerce.Interfaces;
using GenericEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericEcommerce.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        //Salva o pedido
        public void CreateOrder(Order order)
        {
            //preciso gerar o id do pedido, por isso salvei.
            order.OrderDispatched = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();

            var items = _shoppingCart.Items;

            StoresOrderUnitItems(items, order.OrderId);

        }

        //Salva os itens do pedido
        public void StoresOrderUnitItems(IList<ItemShoppingCart> items, long orderId)
        {
            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Quantity = item.Quantity,
                    GameId = item.Game.GameId,
                    OrderId = orderId,
                    Price = item.Game.Price
                };
                _context.OrderItems.Add(orderItem);
            }
            _context.SaveChanges();
        }

        public Order GetOrderById(long orderId)
        {
            return _context.Orders
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Game)
                .Where(x => x.OrderId == orderId)
                .FirstOrDefault();
        }
    }
}
