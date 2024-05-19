using GenericEcommerce.Interfaces;
using GenericEcommerce.Models;
using GenericEcommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GenericEcommerce.Controllers
{
    public class HomeController : Controller
    {   
        private readonly IGameRepository _gameRepository;

        public HomeController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public IActionResult Index()
        {
            return View(new HomeViewModel()
            {
                FavoritesGame = _gameRepository.IsFavoritesGames
            }) ;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}