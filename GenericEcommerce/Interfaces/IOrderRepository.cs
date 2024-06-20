using GenericEcommerce.Models;

namespace GenericEcommerce.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
