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
    }
}
