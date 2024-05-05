using GenericEcommerce.Interfaces;
using GenericEcommerce.ViewModels;
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
            var gamesViewModel = new GameListViewModel();
            gamesViewModel.Games = _gameRepository.Games;

            if(gamesViewModel.Games != null)
            {
                foreach (var item in gamesViewModel.Games)
                {
                    var category = item.Category;
                    if (category?.CategoryId > 0)
                    {
                        gamesViewModel.CurrentCategory = category?.Name; 
                    }
                    else
                    {
                        gamesViewModel.CurrentCategory = "Categoria Atual";
                    }
                }
            }
            

            return View(gamesViewModel);
        }
    }
}
