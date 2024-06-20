using GenericEcommerce.Context;
using GenericEcommerce.Interfaces;
using GenericEcommerce.Models;

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

        public void CreateOrder(Order order)
        {
            //preciso gerar o id do pedido, por isso salvei.
            order.OrderDispatched = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();

            var items = _shoppingCart.Items;

            foreach(var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Quantity = item.Quantity,
                    GameId = item.Game.GameId,
                    OrderId = order.OrderId,
                    Price = item.Game.Price
                };
            _context.OrderItems.Add(orderItem);
            }
            _context.SaveChanges();
        }
    }
}
