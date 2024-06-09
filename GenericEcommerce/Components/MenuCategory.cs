using GenericEcommerce.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GenericEcommerce.Components
{
    public class MenuCategory : ViewComponent
    {
        private readonly ICategoryRepository _categryRepository;

        public MenuCategory(ICategoryRepository categryRepository)
        {
            _categryRepository = categryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categryRepository.Categories.OrderBy(c => c.Name).ToList();

            return View(categories);
        }
    }
}
