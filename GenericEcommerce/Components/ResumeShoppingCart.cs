using GenericEcommerce.Models;
using GenericEcommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenericEcommerce.Components
{
    public class ResumeShoppingCart : ViewComponent
    {private readonly ShoppingCart _shoppingCart;

        public ResumeShoppingCart(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            //_shoppingCart.Items = _shoppingCart.GetItemsToCart();

            _shoppingCart.Items = new List<ItemShoppingCart>()
            {
                new ItemShoppingCart(),
                new ItemShoppingCart()
            };

            return View(new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            });
        }
    }
}
