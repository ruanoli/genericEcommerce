using GenericEcommerce.Interfaces;
using GenericEcommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenericEcommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            int quantOrderItems = 0;
            decimal totalValueOrderItems = 0;

            IList<ItemShoppingCart> cartItems = _shoppingCart.GetItemsToCart();


            if(_shoppingCart.Items.Count == 0)
            {
                ModelState.AddModelError("", "Carrinho de Compras vazio.");
            }

            foreach (var item in cartItems)
            {
                quantOrderItems += item.Quantity;
                totalValueOrderItems += (item.Game.Price * item.Quantity);
            }

            order.TotalOrderItems = quantOrderItems;
            order.TotalOrderValue = totalValueOrderItems;

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);

                ViewBag.CheckoutMessage = "Pedido realizado com sucesso!";
                ViewBag.TotalOrder = _shoppingCart.GetShoppingCartTotal();

                _shoppingCart.CleanCart();

                return View("~/Views/CompleteCheckout.cshtml", order);
            }

            return View(order);
        }
    }
}
