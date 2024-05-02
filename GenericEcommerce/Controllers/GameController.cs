using GenericEcommerce.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GenericEcommerce.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public IActionResult List()
        {
            var games = _gameRepository.Games;

            return View(games);
        }
    }
}
