using GenericEcommerce.Context;
using GenericEcommerce.Interfaces;
using GenericEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericEcommerce.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Categories;
        
    }
}
