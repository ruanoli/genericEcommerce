using GenericEcommerce.Interfaces;
using GenericEcommerce.Migrations;
using GenericEcommerce.Models;
using GenericEcommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenericEcommerce.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IGameRepository gameRepository, ShoppingCart shoppingCart)
        {
            _gameRepository = gameRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            _shoppingCart.Items = _shoppingCart.GetItemsToCart();



            return View(new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            });
        }

        public IActionResult AddItemToCart(int gameId)
        {
            var game = _gameRepository.Games.FirstOrDefault(x => x.GameId == gameId);

            if (game != null)
            {
                _shoppingCart.AddItemToCart(game);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveItemToCart(int gameId)
        {
            var game = _gameRepository.Games.FirstOrDefault(x => x.GameId == gameId);

            if (game != null)
            {
                _shoppingCart.RemoveItemToCart(game);
            }

            return RedirectToAction("Index");
        }
    }
}
