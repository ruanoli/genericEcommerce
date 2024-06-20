using GenericEcommerce.Context;
using GenericEcommerce.Interfaces;
using GenericEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericEcommerce.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public IList<Game> Games => _context.Games
            .Include(x => x.Category)
            .ToList();

        public IList<Game> IsFavoritesGames => _context.Games
            .Where(x => x.IsFavorite)
            .Include(x => x.Category)
            .ToList();

        public Game GetGameById(int id)
        {

            return _context.Games
                        .Where(x => x.GameId == id)
                        .FirstOrDefault();
        }

        public IList<Game> GetGameByCategoryId(int categoryId)
        {
            var games = _context.Games
                        .Where(x => x.Category != null && x.Category.CategoryId == categoryId)
                        .ToList();
            return games;
        }

        public IList<Game> GetGameByName(string name)
        {
            var game = _context.Games.Where(x => x.Name.Contains(name.ToLower())).ToList();

            return game;
        }
    }
}
