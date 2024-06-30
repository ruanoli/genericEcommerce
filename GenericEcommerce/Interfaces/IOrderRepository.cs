using GenericEcommerce.Models;

namespace GenericEcommerce.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void StoresOrderUnitItems(IList<ItemShoppingCart> items, long orderId);
        Order GetOrderById(long orderId);
    }
}
