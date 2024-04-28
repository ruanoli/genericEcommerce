using GenericEcommerce.Models;

namespace GenericEcommerce.Interfaces
{
    public interface IGameRepository
    {
        IList<Game> Games { get; }
        IList<Game> IsFavoritesGames { get; }
        Game GetGameById(int id);
    }
}
