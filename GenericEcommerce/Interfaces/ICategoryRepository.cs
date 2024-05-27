using GenericEcommerce.Models;

namespace GenericEcommerce.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
        Category GetCategoryById(int id);   
    }
}
