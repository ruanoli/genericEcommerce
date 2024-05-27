using GenericEcommerce.Interfaces;
using GenericEcommerce.Models;
using GenericEcommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenericEcommerce.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GameController(IGameRepository gameRepository, ICategoryRepository categoryRepository)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List(int categoryId)
        {
            IEnumerable<Game>? games;
            string currentyCategory = string.Empty;

            if(categoryId > 0) 
            { 
                var category = _categoryRepository.GetCategoryById(categoryId);

                games = _gameRepository.Games.Where(x => x.CategoryId == categoryId).OrderBy(x => x.Name).ToList();
                currentyCategory = category.Name;
            }
            else
            {
                games = _gameRepository.Games.OrderBy(x => x.Name);
                currentyCategory = "Todos os Games";
            }


            return View(new GameListViewModel
            {
                Games = games,
                CurrentCategory = currentyCategory
            });
        }
    }
}
