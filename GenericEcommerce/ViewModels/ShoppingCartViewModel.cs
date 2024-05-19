using GenericEcommerce.Models;

namespace GenericEcommerce.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart? ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
